    public class UpdateVals : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity && 
                context.PreEntityImages != null && context.PreEntityImages.Contains("PreImage"))
            {
                Entity target = (Entity)context.InputParameters["Target"];
                Entity preImage = (Entity)context.PreEntityImages["PreImage"];
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
                try
                {
                    //Get current record's GUID, which will always be in the attributes collection
                    Guid MainEntityID = target.GetAttributeValue<Guid>("msdyn_workorderid");
                    EntityReference RefEntityID = null;
                    if (target.Attributes.Contains("msdyn_agreement"))
                    {
                        RefEntityID = target.GetAttributeValue<EntityReference>("msdyn_agreement");
                    }
                    else if (preImage.Attributes.Contains("msdyn_agreement"))
                    {
                        RefEntityID = preImage.GetAttributeValue<EntityReference>("msdyn_agreement");
                    }
                    //if it has a value, continue
                    if (RefEntityID != null)
                    {
                        Decimal RefEntityFieldValue = GetDecFieldValueFrmID(service, "msdyn_agreement", "msdyn_agreementid", RefEntityID.Id, "client_ntepercent");
                        //if it has a value, continue
                        if (RefEntityFieldValue > -99999999)
                        {
                            target["client_ntepercent"] = RefEntityFieldValue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //write errors to the CRM Plugin Trace Log
                    tracingService.Trace("clientNTE - Agreement To Work Order - ", ex.ToString());
                    //Throw error through UI
                    throw new InvalidPluginExecutionException("Error, Please See Plugin Log");
                }
            }
        }
        public Decimal GetDecFieldValueFrmID(IOrganizationService svc, String EntityNm, String EntityIDField, Guid EntityIDValue, String ReturnFieldNm)
        {
            Decimal retval = -99999999;
            try
            {
                OrganizationServiceContext orgContext = new OrganizationServiceContext(svc);
                var ReturnRecords = from a in orgContext.CreateQuery(EntityNm)
                                    where (Guid)a[EntityIDField] == EntityIDValue
                                    select new
                                    {
                                        FieldVal = a[ReturnFieldNm]
                                    };
                if (ReturnRecords != null)
                {
                    foreach (var EvalRec in ReturnRecords)
                    {
                        retval = Convert.ToDecimal(EvalRec.FieldVal);
                    }
                }
                else
                {
                    retval = -99999999;
                }
            }
            catch (Exception ex)
            {
                retval = -99999999;
                //Throw error through UI
                throw new InvalidPluginExecutionException(ex.ToString());
            }
            return retval;
        }
    }
