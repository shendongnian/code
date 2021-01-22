    public static void WriteObject(string name, object target, XmlWriter writer)
    {
        WriteComplexObject(name, target, writer, new List<object>(), 0, 10, -1);
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
            var formattedPropertyValue = AttemptToFormatPropertyValueAsString(propertyValue);
            if (formattedPropertyValue != null)
            {
                WriteSimpleProperty(writer, property, formattedPropertyValue);
            }
            else if (propertyValue is IEnumerable)
            {
                WriteCollectionProperty(property, depth, maxDepth, recurringObjects, writer, propertyValue, maxListLength);
            }
            else
            {
                WriteComplexObject(property.Name, propertyValue, writer, recurringObjects, depth + 1, maxDepth, maxListLength);
            }
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
    private static string AttemptToFormatPropertyValueAsString(object propertyValue)
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
    private static void WriteSimpleProperty(XmlWriter writer, PropertyInfo property, string formattedPropertyValue)
    {
        writer.WriteStartElement(property.Name);
        writer.WriteValue(formattedPropertyValue);
        writer.WriteEndElement();
    }
    private static void WriteCollectionProperty(PropertyInfo property, int depth, int maxDepth, List<object> recurringObjects, XmlWriter writer, object propertyValue, int maxListLength)
    {
        writer.WriteStartElement(property.Name);
        var enumerator = null as IEnumerator;
        try
        {
            enumerator = ((IEnumerable)propertyValue).GetEnumerator();
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
