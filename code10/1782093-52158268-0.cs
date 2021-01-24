    public class Example
    {
    public byte DocObject {get;set;}
    public string FileName {get;set;}
    }
    List<Example> objList=new List<Example>();
    
    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
    while (rdr.Read())
    {
          Example obj=new Example();
        
         obj.DocObject=(byte[])rdr["DocObject"] //suitable cast
         obj.FileName =rdr["FileName "].toSting() //suitable cast
    
           objList.Add(obj);
    }
    }
        
    }
    
    if (objList.Count > 0)
        {
            Parallel.For (0, objList.Count, i => 
            { 
                byte[] docBytes = (byte[])(objList[i]["DocObject"]);    File.WriteAllBytes(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents\\"), $"{objList[i]["FileName"].ToString().ToLower()}"), docBytes); 
                 });
            }
        }
