    [ProducesResponseType(422)]
    public class ValidateApiModelStateAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            if (!context.ModelState.IsValid) {
                var result = new Dictionary<string, string>();
                foreach (var key in context.ModelState.Keys) {
                    result.Add(key, String.Join(", ", context.ModelState[key].Errors.Select(p => p.ErrorMessage)));
                }
    
                // 422 Unprocessable Entity Explained
                context.Result = new ObjectResult(result) { StatusCode = 422 };
            }
        }
    }
