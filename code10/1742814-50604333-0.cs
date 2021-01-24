    public class AccountPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            var orgService = factory.CreateOrganizationService(null);
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            Entity account = context.PostEntityImages.First().Value;
            var query = new QueryExpression("contact");
            query.Criteria.AddCondition("accountid", ConditionOperator.Equal, context.PrimaryEntityId);
            var result = orgService.RetrieveMultiple(query);
            foreach (Entity contact in result.Entities)
            {
                contact["address1_line1"] = account.GetAttributeValue<string>("address1_line2");
                orgService.Update(contact);
            }
        }
    }
