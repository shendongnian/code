    public class UpdateContactAddresses : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Create a tracing instance to log progress of this plugin.
            ITracingService tracing = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            try
            {
                // Obtain the execution context from the service provider.
                IPluginExecutionContext pluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                // Obtain the organization service reference.
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(null);
                if (pluginExecutionContext.InputParameters.Contains("Target") && pluginExecutionContext.InputParameters["Target"] is Entity)
                {
                    // Obtain the target entity from the input parameters.
                    Entity account = (pluginExecutionContext.InputParameters["Target"] as Entity);
                    // Verify that the target entity represents an account. If not, this plug-in was not registered correctly.
                    if (account.LogicalName != "account")
                    {
                        tracing.Trace("This entity is not an Account entity. It is likely that this plug-in was not registered correctly (was an incorrect \"Primary Entity\" selected? It should be an Account entity).");
                        return;
                    }
                    var query = new QueryExpression("contact");
                    query.Criteria.AddCondition("accountid", ConditionOperator.Equal, pluginExecutionContext.PrimaryEntityId);
                    var result = service.RetrieveMultiple(query);
                    tracing.Trace("The QueryExpression found " + result.TotalRecordCount.ToString() + " associated contacts.");
                    foreach (Entity contact in result.Entities)
                    {
                        tracing.Trace("Updating contact " + contact.ToString() + " address...");
                        contact["address1_line1"] = account.GetAttributeValue<string>("address1_line1");
                        contact["address1_line2"] = account.GetAttributeValue<string>("address1_line2");
                        contact["address1_line3"] = account.GetAttributeValue<string>("address1_line3");
                        contact["address1_city"] = account.GetAttributeValue<string>("address1_city");
                        contact["address1_county"] = account.GetAttributeValue<string>("address1_county");
                        contact["address1_postalcode"] = account.GetAttributeValue<string>("address1_postalcode");
                        contact["address1_country"] = account.GetAttributeValue<string>("address1_country");
                        service.Update(contact);
                        tracing.Trace("Contact " + contact.ToString() + " address updated.");
                    }
                }
                tracing.Trace("Completed execution of plugin " + this.GetType().Name + ".");
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                throw new InvalidPluginExecutionException("An error occurred in plugin " + this.GetType().Name + ".", ex);
            }
            catch (Exception ex)
            {
                tracing.Trace("An error occurred executing plugin " + this.GetType().Name + ".");
                tracing.Trace("\t\tError: " + ex.Message);
                throw ex;
            }
        }
    }
