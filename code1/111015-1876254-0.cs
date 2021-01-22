    <%@ WebHandler Language="C#" Class="Handler" %>
    
    public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        //go to the DB and get the path for this ID.
        string filePath = GetImagePath(context.Request.QueryString["ImageID"]);
        //now you have the path on disk; read the file
        byte[] imgBytes=GetBytesFromDisk(filePath);
        // send back as byte[]
        context.Response.BinaryWrite(imgBytes);
    }
