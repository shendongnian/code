        /// <summary>
        /// The Execute method is called by the workflow runtime to execute an activity.
        /// </summary>
        /// <param name="executionContext"> The context for the activity</param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            // Get the context service.
            IContextService contextService = (IContextService)executionContext.GetService(typeof(IContextService));
            IWorkflowContext context = contextService.Context;
            // Use the context service to create an instance of CrmService.
            ICrmService crmService = context.CreateCrmService(true);
            BusinessEntityCollection newNotes = RetrieveOpportunityProducts(crmService, context.PrimaryEntityId);
            string noteAttrib;
            foreach (DynamicEntity de in newNotes.BusinessEntities)
            {
                noteAttrib = de.Properties.Contains("AnnotationId") ? ((Lookup)de.Properties["annotationid"]).name.ToString() : null;
            }
            return ActivityExecutionStatus.Closed;
        }
