    public class DeleteFileAttribute : ActionFilterAttribute
    {
      public override void OnResultExecuted( ResultExecutedContext filterContext )
      {
        filterContext.HttpContext.Response.Flush();
        string filePath = ( filterContext.Result as FilePathResult ).FileName;
        File.Delete( filePath );
      }
    }
