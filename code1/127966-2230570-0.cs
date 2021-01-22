    Byte[] bytes = null; 
    
    try
    {
    
        if(!FileExists(_filename)) return null;
    
        Byte[fs.Length] bytes 
    
        // get file contents
        using(System.IO.FileStream fs = System.IO.File.Open(_file, FileMode.Open, FileAccess.Read))
        {
        	fs.Read(bytes, 0, fs.Length);
        }
    
    }
    catch(Exception ex)
    {
                System.Text.ASCIIEncoding oEncoder = new System.Text.ASCIIEncoding();
                Byte[] bytes = oEncoder.GetBytes(ex.Message);
    
    }
    
    Context.Response.Buffer = false;
    Context.ClearContent();
    Context.ClearHeaders();
    Context.ContentType = "application/octet-stream"; // Change this type as necessary
    Context.AddHeader("Content-Length", bytes.Length.ToString());
    Context.AddHeader("content-disposition", String.Format("inline; filename={0}", filename));
    Context.Response.BinaryResult(bytes);
    Context.Response.Flush();
