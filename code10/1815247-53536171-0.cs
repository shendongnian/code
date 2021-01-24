    // Set the internal TrimChars via reflection
    public static class FileBaseExtensions
    {
        public static void SetTrimCharsViaReflection(this FieldBase field, Char [] value)
        {
            var prop = typeof(FieldBase).GetProperty("TrimChars", BindingFlags.NonPublic | BindingFlags.Instance);
            prop.SetValue(field, value);
        }
    }
    CsvOptions options = new CsvOptions("Records", ',', filename);
    var engine = new CsvEngine(options);            
    foreach (var field in engine.Options.Fields)
    {
        field.SetTrimCharsViaReflection(new char[] { ' ', '\t' });
        field.TrimMode = TrimMode.Both;
    }
    var dataTable = engine.ReadFileAsDT(filename);
