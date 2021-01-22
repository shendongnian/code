      public class UserModelBinder : IModelBinder
      {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
          User model;
    
          if(controllerContext.RequestContext.HttpContext.Request.AcceptTypes.Contains("application/json"))
          {
            var serializer = new JavaScriptSerializer();
            var form = controllerContext.RequestContext.HttpContext.Request.Form.ToString();
            model = serializer.Deserialize<User>(HttpUtility.UrlDecode(form));
          }
          else
          {
            model = (User)ModelBinders.Binders.DefaultBinder.BindModel(controllerContext, bindingContext);
          }
    
          return model;
        }
      }
