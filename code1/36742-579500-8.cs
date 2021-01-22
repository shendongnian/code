    public static void WriteObject(string name, object target, XmlWriter writer)
    {
        WriteObject(name, target, writer, new List<object>(), 0, 10, -1);
    }
    private static void WriteObject(string name, object target, XmlWriter writer, List<object> recurringObjects, int depth, int maxDepth, int maxListLength)
    {
        var formatted = TryToFormatPropertyValueAsString(target);
        if (formatted != null)
        {
            WriteSimpleProperty(name, formatted, writer);
        }
        else if (target is IEnumerable)
        {
            WriteCollectionProperty(name, (IEnumerable)target, writer, depth, maxDepth, recurringObjects, maxListLength);
        }
        else
        {
            WriteComplexObject(name, target, writer, recurringObjects, depth, maxDepth, maxListLength);
        }
    }
    private static void WriteComplexObject(string name, object target, XmlWriter writer, List<object> recurringObjects, int depth, int maxDepth, int maxListLength)
    {
        if (target == null || depth >= maxDepth) return;
        if (recurringObjects.Contains(target))
        {
            writer.WriteStartElement(name);
            writer.WriteAttributeString("Ref", (recurringObjects.IndexOf(target) + 1).ToString());
            writer.WriteEndElement();
            return;
        }
        recurringObjects.Add(target);
        writer.WriteStartElement(name);
        writer.WriteAttributeString("Ref", (recurringObjects.IndexOf(target) + 1).ToString());
        foreach (var property in target.GetType().GetProperties())
        {
            var propertyValue = ReadPropertyValue(target, property);
            WriteObject(property.Name, propertyValue, writer, recurringObjects, depth + 1, maxDepth, maxListLength);
        }
        writer.WriteEndElement();
    }
    private static object ReadPropertyValue(object target, PropertyInfo property)
    {
        try { return property.GetValue(target, null); }
        catch (Exception ex) { return ReadExceptionMessage(ex); }
    }
    private static string ReadExceptionMessage(Exception ex)
    {
        if (ex is TargetInvocationException && ex.InnerException != null)
            return ReadExceptionMessage(ex.InnerException);
        return ex.Message;
    }
    private static string TryToFormatPropertyValueAsString(object propertyValue)
    {
        var formattedPropertyValue = null as string;
        if (propertyValue == null)
        {
            formattedPropertyValue = string.Empty;
        }
        else if (propertyValue is string || propertyValue is IFormattable || propertyValue.GetType().IsPrimitive)
        {
            formattedPropertyValue = propertyValue.ToString();
        }
        return formattedPropertyValue;
    }
    private static void WriteSimpleProperty(string name, string formattedPropertyValue, XmlWriter writer)
    {
        writer.WriteStartElement(name);
        writer.WriteValue(formattedPropertyValue);
        writer.WriteEndElement();
    }
    private static void WriteCollectionProperty(string name, IEnumerable collection, XmlWriter writer, int depth, int maxDepth, List<object> recurringObjects, int maxListLength)
    {
        writer.WriteStartElement(name);
        var enumerator = null as IEnumerator;
        try
        {
            enumerator = collection.GetEnumerator();
            for (var i = 0; enumerator.MoveNext() && (i < maxListLength || maxListLength == -1); i++)
            {
                if (enumerator.Current == null) continue;
                WriteComplexObject(enumerator.Current.GetType().Name, enumerator.Current, writer, recurringObjects, depth + 1, maxDepth, maxListLength);
            }
        }
        catch (Exception ex)
        {
            writer.WriteElementString(ex.GetType().Name, ReadExceptionMessage(ex));
        }
        finally
        {
            var disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            writer.WriteEndElement();
        }
    }
