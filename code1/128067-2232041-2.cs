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
            BusinessEntity newNote = GetNote(crmService, context.PrimaryEntityId);
            string noteAttrib;
             noteAttrib = newNote.Properties.Contains("AnnotationId") ? ((Lookup)newNote.Properties["annotationid"]).name.ToString() : null;
            return ActivityExecutionStatus.Closed;
        }
