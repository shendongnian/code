    //Define the properties
    [RequiredArgument]
    [Input("Update Next Birthdate for")]
    [ReferenceTarget("contact")]
    public InArgument<EntityReference> Contact { get; set; }
    
    protected override void Execute(CodeActivityContext executionContext)
    {
        IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
    
        //Create an Organization Service
        IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
        IOrganizationService service = serviceFactory.CreateOrganizationService(context.InitiatingUserId);
    
        //Retrieve the contact id
        Guid contactId = this.Contact.Get(executionContext).Id;
    }
