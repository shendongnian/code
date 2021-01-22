    public class CsvExport<T> where T: class
        {
            public List<T> Objects;
    
            public CsvExport(List<T> objects)
            {
                Objects = objects;
            }
    
            public string Export()
            {
                return Export(true);
            }
    
            public string Export(bool includeHeaderLine)
            {
                
                StringBuilder sb = new StringBuilder();
                //Get properties using reflection.
                IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();
    
                if (includeHeaderLine)
                {
                    //add header line.
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(propertyInfo.Name).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }
    
                //add value for each property.
                foreach (T obj in Objects)
                {               
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                    }
                    sb.Remove(sb.Length - 1, 1).AppendLine();
                }
    
                return sb.ToString();
            }
    
            //export to a file.
            public void ExportToFile(string path)
            {
                File.WriteAllText(path, Export());
            }
    
            //export as binary data.
            public byte[] ExportToBytes()
            {
                return Encoding.UTF8.GetBytes(Export());
            }
    
            //get the csv value for field.
            private string MakeValueCsvFriendly(object value)
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
        }
