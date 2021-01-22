                // If this is a setstate call, we need to manually pull the entity
                if (context.InputParameters.Properties.Contains("EntityMoniker") &&
                        context.InputParameters.Properties["EntityMoniker"] is Moniker)
                {
                    Moniker entity = (Moniker)context.InputParameters.Properties["EntityMoniker"];
                    // get the entity
                    TargetRetrieveDynamic targetRet = new TargetRetrieveDynamic();
                    targetRet.EntityId = entity.Id;
                    targetRet.EntityName = context.PrimaryEntityName;
                    RetrieveRequest retrieveReq = new RetrieveRequest();
                    retrieveReq.ColumnSet = new ColumnSet();
                    retrieveReq.ColumnSet.AddColumns(new string[]{"opportunityid", "statecode", "statuscode"});
                    retrieveReq.Target = targetRet;
                    retrieveReq.ReturnDynamicEntities = true;
                    RetrieveResponse retrieveRes = this.Service.Execute(retrieveReq) as RetrieveResponse;
                    // Set the new entity and the status
                    int status = (int)context.InputParameters["Status"];
                    dynEntity = (DynamicEntity)retrieveRes.BusinessEntity;                                        
                    dynEntity.Properties["statuscode"] = new Status(status);                      
                }
