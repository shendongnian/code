    function CreateRenewals() {
        Xrm.Page.ui.setFormNotification("Please wait, this may take some time..", "INFORMATION", "1");
        Process.callAction("gc_CreateRenewalOpportunity",
                [{
                    key: "TargetOrder",
                    type: Process.Type.EntityReference,
                    value: new Process.EntityReference("salesorder", Xrm.Page.data.entity.getId())
                }],
                function (params) {
                    debugger;//Success
                    Xrm.Page.ui.clearFormNotification("1");
                    Xrm.Page.ui.setFormNotification(params.Result, "INFORMATION", "2");
                },
                function (e, t) {
                    Xrm.Page.ui.clearFormNotification("1");
                    Xrm.Page.ui.setFormNotification(params.Result, "INFORMATION", "3");
                    // Error
                });
    }
**************************
  
        public void Execute(IServiceProvider serviceProvider)
            {
                ITracingService tracer = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);
    
                try
                {
                    Entity entity = null;
                    if (context.InputParameters.Contains("TargetOrder"))
                    {
                        if (context.InputParameters["TargetOrder"] is Entity)
                            entity = (Entity)context.InputParameters["TargetOrder"];
                        else if (context.InputParameters["TargetOrder"] is EntityReference)
                        {
                            EntityReference entityRef = (EntityReference)context.InputParameters["TargetOrder"];
                            entity = service.Retrieve(entityRef.LogicalName, entityRef.Id, new Microsoft.Xrm.Sdk.Query.ColumnSet(true));
                        }
                    }
                    context.OutputParameters["Result2"] = new EntityCollection(new List<Entity> { entity });
    }
