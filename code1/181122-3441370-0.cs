    // An assumed method to get binary data our of the database  
    var bytes = YourDataLayer.GetBinaryImageData();  
    Response.Clear();   
    Response.AddHeader("Content-Disposition","attachment;filename=filename.jpg");   
    Response.ContentType = @"image\jpg";   
    Response.BinaryWrite(bytes);   
    Response.End();  
