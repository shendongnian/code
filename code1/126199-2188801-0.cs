    public class AttachmentHandler : IHttpHandler
    {
      public const string QueryKeyID = "ID";
      public void ProcessRequest(HttpContext context)
      {    
        var r = context.Response;
        var attachmentID = context.Request.QueryString[QueryKeyID];
    
        Attachment a = DataContext.GetById<AttachmentFile>(attachmentID);
    
        r.ContentType = a.ContentType;
        r.AppendHeader("Content-Type", a.ContentType);
        r.AppendHeader("content-disposition", string.Format("attachment; filename=\"{0}{1}\"", a.AttachmentName, GetExtension(a.FileName)));
        r.BufferOutput = false; //Stream the content to the client, no need to cache entire streams in memory...
        r.BinaryWrite(a.BlobData);
        r.End();
      }
    
      private static string GetExtension(string fileName)
      {
        if(fileName.IsNullOrEmpty()) return string.Empty;
        var i = fileName.LastIndexOf(".");
        return i > 0 ? fileName.Substring(i) : string.Empty;
      }
    }
