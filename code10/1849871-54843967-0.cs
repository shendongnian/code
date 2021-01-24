    class BaseController
    {
         protected static IActionResult GenericAction(object request)
         {
               var result = Mediatr.Send(request);
               if(result == null)
               {
                   return NotFound();
               }
               return Ok(result);
         }
    }
