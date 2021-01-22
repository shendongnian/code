    foreach (ServiceEndpoint ep in host.Description.Endpoints)
            {
                foreach (OperationDescription op in ep.Contract.Operations)
                {
                    var dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>();
                    if (dataContractBehavior != null)
                    {
                        dataContractBehavior.DataContractSurrogate = new HibernateDataContractSurrogate();
                    }
                    else
                    {
                        dataContractBehavior = new DataContractSerializerOperationBehavior(op);
                        dataContractBehavior.DataContractSurrogate = new HibernateDataContractSurrogate();
                        op.Behaviors.Add(dataContractBehavior);
                    }
                }
            }
