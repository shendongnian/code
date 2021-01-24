    [HttpPost]
    public JsonResult AddServices(ServiceViewModel model)
    {
        if(model == null)
           return null;
        var addService = new Services(); 
        //Use Automapper for mapping view models to data entities
        addService.ServiceID = model.ServiceID ;  //Service Id should be auto incremented from database
        addService.ServiceName = model.ServiceName ;
        addService.ServicePrice = model.ServicePrice ;
        addService.EntryDateTime = model.EntryDateTime ;
        addService.IsOwner = model.IsOwner ;
        addService.Commission = model.Commission ;
        ServicesRepository servicesRep = new ServicesRepository();
        int i = 0;
        //i = ServicesRep.UpdateServices(UpdateServicesVM, out ReturnStatus, out ReturnMessage);
        //Don't write the data specific logic in controllers. Use Repository Pattern.
        ZahidCarWashDBEntities context = new ZahidCarWashDBEntities();
        context.Services.Add(addService);
        context.SaveChanges();
        return Json(new { ReturnMessageJSON = ReturnMessage, ReturnStatusJSON = ReturnStatus });  
          
