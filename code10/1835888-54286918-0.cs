    //get full physical path of file including its name
    string fullFileName =  Request.PhysicalApplicationPath + fileName); 
    
    //read contents of file at above location and modify Response header 
    //so browser knows response is not html but a csv file content
    byte[] Content= File.ReadAllBytes(fullFileName);  
    Response.ContentType = "text/csv";
    Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
    Response.BufferOutput = true;
    Response.OutputStream.Write(Content, 0, Content.Length);
    Response.End();
