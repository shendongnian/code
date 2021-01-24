    public static Stream ConvertToCSVStream<T>(IEnumerable<T> objects)
           {
              Type itemType = typeof(T);
              var properties = itemType.GetProperties();
            var mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(mStream);
            var values = objects.Select(o =>
            {
                return string.Join(",", properties.Select(p =>
                {
                    var value = p.GetValue(o).ToString();
                    if (!Regex.IsMatch(value, "[,\"\\r\\n]"))
                    {
                        return value;
                    }
                    value = value.Replace("\"", "\"\"");
                    return string.Format("\"{0}\"", value);
                })) + sWriter.NewLine;
            });
            var valuesInStrings = values.Aggregate((current, next) => current + next);
            try
            {
                sWriter.Write(string.Join(",", properties.Select(x => x.Name.Replace("_", " "))) + sWriter.NewLine);
                sWriter.Write(valuesInStrings);
            }
            catch (Exception e)
            {
                mStream.Close();
                throw e;
            }
            sWriter.Flush();
            mStream.Position = 0;
            return mStream;
        }
