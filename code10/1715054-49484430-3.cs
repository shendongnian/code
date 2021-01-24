     public class ResponseWriteActionResult : ActionResult
     {
          public override void ExecuteResult(ActionContext context)
          {
              var str = Encoding.ASCII.GetBytes("Hello World !");
    
              context.HttpContext.Response.Body.Write(str, 0, str.Length);
          }
     }
