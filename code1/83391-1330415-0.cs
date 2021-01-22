    public class MyController : Controller
    {
      public ActionResult MyActionMethod(UserChangeModel model)
      {
         if (!ModelState.IsValid)
         {
            return RedirectToAction("Index");      
         }
       
         User user = _userService.GetUser(model.Id);
         user.Name = model.Name;
         user.Email = model.Email;
         user.Group = _groupService.GetGroup(model.IdGroup);     
         return View(user);
      }
    }
    public class MyDefaultModelBinder : DefaultModelBinder
    {   
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var boundInstance = base.BindModel(controllerContext, bindingContext);
            if (boundInstance != null)
            {
                var validator = findValidator(bindingContext.ModelType);
                var errors = validator.Validate(boundinstance);
                addErrorsToTheModelState(bindingContext, errors);
            }
        }
    }
   
