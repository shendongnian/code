        public bool CreateOrUpdateEmployee(Common common)
        {
			bool IstransactionComplete= false;
            EmployeeEntities DbContext = new EmployeeEntities();
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    if (common.Mode == Modes.CREATE) //Modes - User defined Enum
                    {
                        DbContext = CreateFinanceEmployees(common, DbContext); //DbContext.savechanges() inside this method.
						
						DbContext = CreateManufacturingEmployee(common, DbContext); //DbContext.savechanges() inside this method.
						
						DbContext = CreateLogisticsEmployee(common, DbContext);  //DbContext.savechanges() inside this method.
                    }
                    else
                    {
                        DbContext = UpdateFinanceEmployees(common, DbContext);  //DbContext.savechanges() inside this method.
						
						DbContext = UpdateManufacturingEmployee(common, DbContext);  //DbContext.savechanges() inside this method.
						
						DbContext = UpdateLogisticsEmployee(common, DbContext);  //DbContext.savechanges() inside this method.
                    }
                    **transaction.Commit();**
					
                    IstransactionComplete=true;
                }
                catch (Exception ex)
                {
                    **transaction.Rollback();**
					
					IstransactionComplete=false;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
            return IstransactionComplete;
        }
		
		
