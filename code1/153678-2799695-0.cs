    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var result = filterContext.Controller.ValueProvider.GetValue("GroupId"); //groupId should be of type `ValueProviderResult`
            
            if (result != null)
            {
                int groupId = int.Parse(result.AttemptedValue);
                //Authorize the user using the groupId   
            }
       }
