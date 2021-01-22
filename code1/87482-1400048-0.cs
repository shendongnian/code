    public class StoreModelBinder : DefaultModelBinder
    {
        protected override void OnModelUpdated(ControllerContext controllerContext,
                                               ModelBindingContext bindingContext)
        {
            Store store= 
                (Store)(bindingContext.Model ?? new Store());
    
            // For example...
            store.ID = Convert.ToInt32(controllerContext.HttpContext.Request["storeID"]);
            // Set other properties...
        }
    }
