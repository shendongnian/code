    class AnyClassToBeSerialized
    {
        public DataTable KeyValuePairs { get; }
        public AnyClassToBeSerialized
        {
            KeyValuePairs = new DataTable();
            KeyValuePairs.Columns.Add("Key", typeof(string));
            KeyValuePairs.Columns.Add("Value", typeof(string));
        }
        public void AddEntry(string key, string value)
        {
            DataRow row = KeyValuePairs.NewRow();
            row["Key"] = key; // "Key" & "Value" used only for example
            row["Value"] = value;
            KeyValuePairs.Rows.Add(row);
        }
    }
