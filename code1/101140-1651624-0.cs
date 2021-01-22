    public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var thingToView = filterContext.ActionParameters[_thingToView] as thingToView ;
                var registration = filterContext.ActionParameters[_registration] as Registration;
    
    
                if (!registration.CanSeeThing(ThingToView))
                {
                    throw new RegistrationCannotViewThing(registration, thingToView);
                }
    
                base.OnActionExecuting(filterContext);
            }
