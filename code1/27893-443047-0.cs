    public class MyController : Controller {
        public ActionResult MyAction(string submitButton) {
            switch(submitButton) {
                case "Send":
                    // delegate sending to another controller action
                    return(Send());
                case "Cancel":
                    // call another action to perform the cancellation
                    return(Cancel());
                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return(View());
            }
        }
        
        private ActionResult Cancel() {
            // process the cancellation request here.
            return(View("Cancelled"));
        }
        private ActionResult Send() {
            // perform the actual send operation here.
            return(View("SendConfirmed"));
        }
    }
    
