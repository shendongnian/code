    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Project.Structure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    
    namespace Project.Attributes
    {
       public class ValidateModelAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    var errorList = new List<string>();
                    foreach (var modelError in context.ModelState.Values)
                    {
                        errorList.AddRange(modelError.Errors.Select(error => error.ErrorMessage));
                    }
    
                    var response = new ResponseDto<object>
                    {
                        Success = false,
                        TransactionId = Guid.NewGuid().ToString(),
                        ResponseType = ResponseType.Operation.Description(),
                        Response = null,
                        Errors = errorList,
                        Warnings = null
                    };
    
                    context.Result = new BadRequestObjectResult(response);
                }
            }
        }
    }
