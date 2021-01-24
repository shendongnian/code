    class BaseController<TRequest>
    { 
         public virtual Action Foo(SomeRequest request)
         {
             return GenericAction(request);
         } 
 
         protected static IActionResult GenericAction(TRequest request)
         {
               var result = Mediatr.Send(request);
               if(result == null)
               {
                   return NotFound();
               }
               return Ok(result);
         }
    }
