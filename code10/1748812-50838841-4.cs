    public class ValidateCustomerModelAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            var ModelState = context.Controller.ViewData.ModelState;
            var customerDatabase = (MyModel)ModelState.Value; //cast to expected model type
            if (ModelState.IsValidField("Name") && customerDatabase.Name== null) {
                ModelState.AddModelError("Name", "The customer's name is required.");
            }
            if (ModelState.IsValidField("AccountNumber") && customerDatabase.AccountNumber.Length != 10) {
                ModelState.AddModelError("AccountNumber", "The customer's account number must be 10 digits long.");
            }
            if (ModelState.IsValidField("Address") && customerDatabase.Address == null) {
                ModelState.AddModelError("Address", "The customer's address is required.");
            }
            
            //...
        }
    }
    
