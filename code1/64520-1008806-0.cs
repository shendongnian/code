    private string GetString(HtmlTextWriter writer) 
    {
       // the flags to see the internal properties of the writer
       System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Default;
       flags |= System.Reflection.BindingFlags.NonPublic;
       flags |= System.Reflection.BindingFlags.Instance;
       flags |= System.Reflection.BindingFlags.FlattenHierarchy;
       flags |= System.Reflection.BindingFlags.Public;
    
       // get the information about the internal TextWriter object
       System.Reflection.FieldInfo baseWriter = writer.GetType().GetField("writer", flags);
    
       // use that info to create a StringWriter
       System.IO.StringWriter reflectedWriter = (System.IO.StringWriter)baseWriter.GetValue(writer);
    
       // now we get a StringBuilder!
       StringBuilder builder = reflectedWriter.GetStringBuilder();
    
       return builder.ToString();
    }
