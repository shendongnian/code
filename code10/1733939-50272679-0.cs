    public class CustomErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            try{
                //Send email
            }
            catch{
               //Swallow...
            }
            base.OnException(filterContext);
        }
    }
