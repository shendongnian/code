    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Crm.Sdk.Messages;
    using System.ServiceModel;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    
    namespace CLIENTNTE
    {
        public class NTEExceedance : IPlugin
        {
            public void Execute(IServiceProvider serviceProvider)
            {
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);
                ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
    
    
                Decimal nte_percent = 0;
                Decimal subtotalDecimal = 0;
                Decimal nteDecimal = 0;
                Decimal amountDiffDecimal = 0;
                Decimal percentDifference = 0;
                try
                {
    
                    if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                    {
                        Entity entity = (Entity)context.InputParameters["Target"];
                        //if entity is not Work Order, return.  Prevents plugin firing on wrong entity (in case of wrong registration in plugin registration tool)
                        if (entity.LogicalName != "msdyn_workorder")
                        {
                            return;
                        }
                        //get preimage of WO Entity
                        Entity preMessageImage = (Entity)context.PreEntityImages["WONTEPreImage"];
    
                        //logic for when updated attribute is NTE Amount
                        if (entity.Attributes.Contains("CLIENT_nteamount") == true)
                        {
                            nteDecimal = entity.GetAttributeValue<Money>("CLIENT_nteamount").Value;
                        }
                        else
                        {
                            nteDecimal = preMessageImage.GetAttributeValue<Money>("CLIENT_nteamount").Value;
                        }
                        //logic for when updated attribute is NTE Percent
                        if (entity.Attributes.Contains("CLIENT_ntepercent") == true)
                        {
                            nte_percent = entity.GetAttributeValue<Decimal>("CLIENT_ntepercent");
                        }
                        else
                        {
                            nte_percent = preMessageImage.GetAttributeValue<Decimal>("CLIENT_ntepercent");
                        }
                        //logic for when updated attribute is Estimate Subtotal Amount
                        if (entity.Attributes.Contains("msdyn_estimatesubtotalamount") == true)
                        {
                            subtotalDecimal = entity.GetAttributeValue<Money>("msdyn_estimatesubtotalamount").Value;
                        }
                        else
                        {
                            subtotalDecimal = preMessageImage.GetAttributeValue<Money>("msdyn_estimatesubtotalamount").Value;
                        }
    
                        //calculation of Amount Difference, and Percent Difference
                        amountDiffDecimal = (subtotalDecimal - nteDecimal);
                        percentDifference = ((amountDiffDecimal / nteDecimal) * 100);
    
                        //Comparison logic to update the NTE Exceeded flag
                        if (percentDifference > nte_percent)
                        {
                            entity["CLIENT_nteexceeded"] = true;
                        }
                        if (percentDifference <= nte_percent)
                        {
                            entity["CLIENT_nteexceeded"] = false;
                        }
                    }
                }
                catch (FaultException<OrganizationServiceFault> e)
                {
                    //write errors to the CRM Plugin Trace Log
                    tracingService.Trace("CLIENTPlugin - Update NTEExceededNonCalc: {0}", e.ToString());
                    //Throw error through UI
                    throw new InvalidPluginExecutionException("Error, Please See Plugin Log");
                }
            }
        }
    }
