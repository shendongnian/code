    public class DeleteFileAttribute : ActionFilterAttribute
    {
      public override void OnResultExecuted(ResultExecutedContext filterContext)
      {
         filterContext.HttpContext.Response.Flush();
         var filePathResult = filterContext.Result as FilePathResult;
         if (filePathResult != null)
         {
            System.IO.File.Delete(filePathResult.FileName);
         }
      }
    }
