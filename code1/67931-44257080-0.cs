        public List<Entity> GetEntitiesCollection(IOrganizationService service, string entityName, ColumnSet col)
      {
                            try
                            {
                                QueryExpression query = new QueryExpression
                                {
                                    EntityName = entityName,
                                    ColumnSet = col
                                };
                                var testResult = service.RetrieveMultiple(query);
                                var testResultSorted = testResult.Entities.OrderBy(x => x.LogicalName).ToList();
                
                 foreach (Entity res in testResultSorted)
                            {
                                var keySorted = res.Attributes.OrderBy(x => x.Key).ToList();
                                DataRow dr = null;
                                dr = dt.NewRow();
                                foreach (var attribute in keySorted)
                                {
                                    try
                                    {
                                        if (attribute.Value.ToString() == "Microsoft.Xrm.Sdk.OptionSetValue")
                                        {
                                            var valueofattribute = GetoptionsetText(entityName, attribute.Key, ((Microsoft.Xrm.Sdk.OptionSetValue)attribute.Value).Value, _service);
    dr[attribute.Key] = valueofattribute;
  
                                            }
                                            else if (attribute.Value.ToString() == "Microsoft.Xrm.Sdk.EntityReference")
                                            {
                                                dr[attribute.Key] = ((Microsoft.Xrm.Sdk.EntityReference)attribute.Value).Name;
                                            }
                                            else
                                            {
                                                dr[attribute.Key] = attribute.Value;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Response.Write("<br/>optionset Error is :" + ex.Message);
                                        }
                                    }
                                    dt.Rows.Add(dr);
                                }
                     return testResultSorted;
                     }
                            catch (Exception ex)
                            {
                                Response.Write("<br/> Error Message : " + ex.Message);
                                return null;
                            }
                }
