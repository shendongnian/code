    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    namespace MyExtension
    {
        public static void BindViewModel<T>(this Controller controller, T model)
        {
            if (model == null) return;
            
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                controller.ModelState.Clear();
                foreach (ValidationResult result in results)
                {
                    var key = result.MemberNames.FirstOrDefault() ?? "";
                    controller.ModelState.AddModelError(key, result.ErrorMessage);
                }
            }
        }
    }
