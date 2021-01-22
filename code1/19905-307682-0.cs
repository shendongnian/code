        public Response<SomeObject> SaveSomething(Object yourObject)
        {
            DbTransaction dbTransaction = null;
            try
            {
                using (DataContext context = new DataContext())
                {
                        //Creates a new DB transaction
                        if (context.Connection.State == System.Data.ConnectionState.Closed)
                        {
                            context.Connection.Open();
                        }
                        dbTransaction = context.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable);
                        context.Transaction = dbTransaction;
			 context.SaveYourObject(yourObject);
                        //Commit the transaction
                        dbTransaction.Commit();
                        response.ResponseObject = yourObject;
                        response.Messages.AddSuccessfulSave("Saved!");
                    }
                }
            }
            catch (ChangeConflictException cex)
            {
                if (dbTransaction != null) dbTransaction.Rollback();
                response.Errors.AddConcurrencyError();
                response.IsSuccessful = false;
            }
            catch (SqlException sqlEx)
            {
                if (dbTransaction != null) dbTransaction.Rollback();
                if (sqlEx.Class == 14 && (sqlEx.Number == 2601 || sqlEx.Number == 2627)) //Duplicated key
                {
                    response.Errors.Add(new Error
                    {
                        Name = "Duplicate item",
                        Description = "This object already exists."
                    });
                    ExceptionPolicy.HandleException(sqlEx, SERVICE_EXCEPTION_POLICY);
                    response.IsSuccessful = false;
                }
                else //other SQL errors
                {
                    response.Errors.AddSavingError("Your object", yourObjectId);
                    ExceptionPolicy.HandleException(sqlEx, SERVICE_EXCEPTION_POLICY);
                    response.IsSuccessful = false;
                }
            }
