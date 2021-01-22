    Response.ContentType = "application/pdf"; 
    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", file.FileName)); 
    Response.BinaryWrite(file.FileBytes); 
    Response.Flush(); 
    Response.End();
