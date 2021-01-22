    public class CsvExport
    {
        List<string> fields = new List<string>();
    
        public string addTitle { get; set; } // string for the first row of the export
    
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> currentRow
        {
            get
            {
                return rows[rows.Count - 1];
            }
        }
    
        public object this[string field]
        {
            set
            {
                if (!fields.Contains(field)) fields.Add(field);
                currentRow[field] = value;
            }
        }
    
        public void AddRow()
        {
            rows.Add(new Dictionary<string, object>());
        }
    
        string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is Nullable && ((INullable)value).IsNull) return "";
            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();
            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';
            return output;
    
        }
    
        public string Export()
        {
            StringBuilder sb = new StringBuilder();
    
            // if there is a title
            if (!string.IsNullOrEmpty(addTitle))
            {
                // escape chars that would otherwise break the row / export
                char[] csvTokens = new[] { '\"', ',', '\n', '\r' };
    
                if (addTitle.IndexOfAny(csvTokens) >= 0)
                {
                    addTitle = "\"" + addTitle.Replace("\"", "\"\"") + "\"";
                }
                sb.Append(addTitle).Append(",");
                sb.AppendLine();
            }
    
    
            // The header
            foreach (string field in fields)
            sb.Append(field).Append(",");
            sb.AppendLine();
    
            // The rows
            foreach (Dictionary<string, object> row in rows)
            {
                foreach (string field in fields)
                    sb.Append(MakeValueCsvFriendly(row[field])).Append(",");
                sb.AppendLine();
            }
    
            return sb.ToString();
        }
    
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, Export());
        }
    
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }
    }
