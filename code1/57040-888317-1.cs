        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=FileName.csv");
        Response.Charset = "";
        Response.ContentType = "application/text";
        Response.Output.Write(ExampleClass.ConvertToCSV(GetListOfObject(), typeof(object)));
        Response.Flush();
        Response.End();
    public static string ConvertToCSV(IEnumerable col, Type type)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder header = new StringBuilder();
    
                // Gets all  properies of the class
                PropertyInfo[] pi = type.GetProperties();
    
                // Create CSV header using the classes properties
                foreach (PropertyInfo p in pi)
    
                {
                    header.Append(p.Name + ",");
                }
    
    
                sb.AppendLine(header.ToString().Remove(header.Length));
    
    
                foreach (object t in col)
    
                {
    
                    StringBuilder body = new StringBuilder();
    
                    // Create new item
                    foreach (PropertyInfo p in pi)
    
                    {
                        object o = p.GetValue(t, null);
                        body.Append(o.ToString() + ",");
                    }
    
                    sb.AppendLine(body.ToString().Remove(body.Length));
    
                }
                return sb.ToString();
            }
