        public bool SaveDataCapDetails(List<TDataCapDetails> lstDataCapDetails)
        {
            bool IsSuccess = false;
            using (var dbContextTransaction = _objContext.Database.BeginTransaction())
            {
                try
                {
                    List<TDataCapDetails> lstDataCapDetailsRecords = null;
                    if (lstDataCapDetails.Where(x => x.Id == 0).Count() > 0)
                    {
                        lstDataCapDetailsRecords = new List<TDataCapDetails>();
                        _objContext.AddRange(lstDataCapDetailsRecords);
                        _objContext.SaveChanges();
                    }
                    if (lstDataCapDetails.Where(x => x.Id > 0).Count() > 0)
                    {
                        lstDataCapDetailsRecords = new List<TDataCapDetails>();
                        lstDataCapDetailsRecords = lstDataCapDetails.Where(x => x.Id > 0).ToList();
                        _objContext.UpdateRange(lstDataCapDetailsRecords);
                        _objContext.SaveChanges();
                    }
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
            return IsSuccess;
        }
