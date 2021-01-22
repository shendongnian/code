        public ActionResult AnAction(Claim claim)
        {
          if (!ModelState.IsValid)
            return View("Invalid claim"); 
        }
        
        public class ClaimModelBinder: IModelBinder
        {
          public object BindModel(BindingContext context) // don't remember exactly
          {
              var id = context.ValueProvider.GetRawValue(context.ModelName);
              if (string.IsNullOrEmpty(id))
              {
                   context.ModelState.AddModelError(context.ModelName, "Empty id");
                   return null;
              }
              var claim = GetClaim(id);
              if (claim == null)
              {
                   context.ModelState.AddModelError(context.ModelName, "Invalid claim");
                   return null;
              }
              return claim;
          }
        }
        
        // in global.asax.cs
        ModelBinders.Binders.Add(typeof(Claim), new ClaimCustomerBinder());
    
