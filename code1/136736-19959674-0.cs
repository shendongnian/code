    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlTypes;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
     
        public class CsvExport
        {
    
            public char delim = ';';
            /// <summary>
            /// To keep the ordered list of column names
            /// </summary>
            List<string> fields = new List<string>();
    
            /// <summary>
            /// The list of rows
            /// </summary>
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
    
            /// <summary>
            /// The current row
            /// </summary>
            Dictionary<string, object> currentRow { get { return rows[rows.Count - 1]; } }
    
            /// <summary>
            /// Set a value on this column
            /// </summary>
            public object this[string field]
            {
                set
                {
                    // Keep track of the field names, because the dictionary loses the ordering
                    if (!fields.Contains(field)) fields.Add(field);
                    currentRow[field] = value;
                }
            }
    
            /// <summary>
            /// Call this before setting any fields on a row
            /// </summary>
            public void AddRow()
            {
                rows.Add(new Dictionary<string, object>());
            }
    
            /// <summary>
            /// Converts a value to how it should output in a csv file
            /// If it has a comma, it needs surrounding with double quotes
            /// Eg Sydney, Australia -> "Sydney, Australia"
            /// Also if it contains any double quotes ("), then they need to be replaced with quad quotes[sic] ("")
            /// Eg "Dangerous Dan" McGrew -> """Dangerous Dan"" McGrew"
            /// </summary>
            string MakeValueCsvFriendly(object value)
            {
                if (value == null) return "";
                if (value is INullable && ((INullable)value).IsNull) return "";
                if (value is DateTime)
                {
                    if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                        return ((DateTime)value).ToString("yyyy-MM-dd");
                    return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                }
                string output = value.ToString();
                if (output.Contains(delim) || output.Contains("\""))
                    output = '"' + output.Replace("\"", "\"\"") + '"';
                if (Regex.IsMatch(output,  @"(?:\r\n|\n|\r)"))
                    output = string.Join(" ", Regex.Split(output, @"(?:\r\n|\n|\r)"));
                return output;
            }
    
            /// <summary>
            /// Output all rows as a CSV returning a string
            /// </summary>
            public string Export()
            {
                StringBuilder sb = new StringBuilder();
    
                // The header
                foreach (string field in fields)
                    sb.Append(field).Append(delim);
                sb.AppendLine();
    
                // The rows
                foreach (Dictionary<string, object> row in rows)
                {
                    foreach (string field in fields)
                        sb.Append(MakeValueCsvFriendly(row[field])).Append(delim);
                    sb.AppendLine();
                }
    
                return sb.ToString();
            }
    
            /// <summary>
            /// Exports to a file
            /// </summary>
            public void ExportToFile(string path)
            {
                File.WriteAllText(path, Export());
            }
    
            /// <summary>
            /// Exports as raw UTF8 bytes
            /// </summary>
            public byte[] ExportToBytes()
            {
                return Encoding.UTF8.GetBytes(Export());
                
            }
    
        }
