    BackgroundWorkerHelper.DoWork<Type of object you want to retrieve>(
                       () =>
                       {
                          //Load your data here
                          //Like
                            using (MarketingService svc = new MarketingService())
                            {
                                return svc.GetEmployeeLookupTable();
                            }
                       },
                           (args) =>
                           {
                               this.IsEnable = true;
                               if (args.Error == null)
                               {
                                   Your Target Datasource= args.Result;
                               }
                           });
    
    this.IsEnable = false;
