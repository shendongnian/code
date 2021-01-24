    using System;
    using System.Activities;
    using System.Linq;
    
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Sdk.Workflow;
    
    namespace Dyn365Apps.CRM.Workflow
    {
        public class ExtractAttachmentsFromEmailAndCreateNotes : CodeActivity
        {
            [RequiredArgument]
            [Input("Email")]
            [ReferenceTarget("email")]
            public InArgument<EntityReference> receivedEmail { get; set; }
    
            [RequiredArgument]
            [Input("Enquiry")]
            [ReferenceTarget("incident")]
            public InArgument<EntityReference> enquiry { get; set; }
    
            protected override void Execute(CodeActivityContext context)
            {
                var trace = context.GetExtension<ITracingService>();
    
                try
                {
                    var serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
                    var service = serviceFactory.CreateOrganizationService(Guid.Empty); //Use current user's ID
                    
                    if (service != null)
                    {
                        trace.Trace("Organization Service Created");
                    }
    
                    // Get Attachment Count
                    trace.Trace("Get Attachment Count");
                    var rem = receivedEmail.Get(context);
                    Entity email = service.Retrieve(rem.LogicalName, rem.Id, new ColumnSet("attachmentcount"));
                    int atc = (int)email["attachmentcount"];
                    trace.Trace("Attachment count = " + atc.ToString());
    
                    if (atc > 0)
                    {
                        // Get all attachments
                        QueryExpression queryAtt = new QueryExpression("activitymimeattachment");
                        queryAtt.ColumnSet = new ColumnSet(new string[] { "activityid", "attachmentid", "filename", "body", "mimetype", "subject" });
                        queryAtt.Criteria = new FilterExpression();
                        queryAtt.Criteria.FilterOperator = LogicalOperator.And;
                        queryAtt.Criteria.AddCondition(new ConditionExpression("activityid", ConditionOperator.Equal, email.Id));
                        EntityCollection eatt = service.RetrieveMultiple(queryAtt);
                        var entities = eatt.Entities;
    
                        trace.Trace("Entities count = " + entities.Count());
    
                        foreach (var ent in entities)
                        {                        
                            trace.Trace("Inside the for loop");
                            trace.Trace("Attributes count = " + ent.Attributes.Count());
    
                            // Instantiate an Annotation object.
                            Entity annotation = new Entity("annotation");
    
                            if (ent.Attributes.Contains("subject"))
                            {
                                trace.Trace("subject = " + ent.Attributes["subject"].ToString());
                                annotation["subject"] = ent.Attributes["subject"].ToString();
                            }
                            else
                            {
                                trace.Trace("subject not found");
                                annotation["subject"] = "Undefined";
                            }
                            
                            if(ent.Attributes.Contains("filename"))
                            {
                                trace.Trace("filename = " + ent.Attributes["filename"].ToString());
                                annotation["filename"] = ent.Attributes["filename"].ToString();
                            }
                            else
                            {
                                trace.Trace("filename not found");
                                annotation["filename"] = "Undefined.txt";
                            }
    
                            if (ent.Attributes.Contains("mimetype"))
                            {
                                trace.Trace("mimetype = " + ent.Attributes["mimetype"].ToString());
                                annotation["mimetype"] = ent.Attributes["mimetype"].ToString();
                            }
                            else
                            {
                                trace.Trace("mimetype not found");
                                annotation["mimetype"] = "plain/text";
                            }
    
                            if (ent.Attributes.Contains("body"))
                            {
                                annotation["documentbody"] = ent.Attributes["body"];
                            }
                            
                            trace.Trace("objectid = " + enquiry.Get(context).Id.ToString());
                            
                            annotation["objectid"] = enquiry.Get(context);
                            annotation["objecttypecode"] = 112; // Case
    
                            // Create a Note with the attachment
                            service.Create(annotation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    trace.Trace("ex.Message = {0}", ex.Message);
                    trace.Trace("ex.StackTrace = {0}", ex.StackTrace);
                }
            }
        }
    }
