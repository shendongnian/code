    public  async Task<bool> SaveOrUpdate(IEnumerable<TaxLaw> obj)
        {
            using (var trans = _taxhistoryrepo.DbContext.Database.BeginTransaction())
            {
                foreach (var list in obj)
                {
                    _taxhistoryrepo.DbSetEntity.Add(new TaxTableHistory {
		            	CompanyCode = list.CompanyCode,
                        CummulativeAmount = list.CummulativeAmount,
                        Percentage = list.Percentage,
                        ModifiedDate = DateTime.UtcNow,
                        ModifiedDate = list.ModifiedDate,
                        Status = EntityStatus.Active
		        });
                await  _taxhistoryrepo.DbContext.SaveChangesAsync();
                await  Task.FromResult(_repository.SingleSave(obj));
             }
             trans.Commit();
            }
            return true;
        }
