     public  async Task<bool> SaveOrUpdate(IEnumerable<TaxLaw> obj)
        {
            using (var trans = _taxhistoryrepo.DbContext.Database.BeginTransaction())
            {
              var lists = new List<TaxTableHistory>();
                foreach (var list in obj)
                {
                        var taxHistory = new TaxHistory();
                        taxHistory.CompanyCode = list.CompanyCode;
                        taxHistory.CummulativeAmount = list.CummulativeAmount;
                        taxHistory.Percentage = list.Percentage;
                        taxHistory.ModifiedDate = DateTime.UtcNow;
                        taxHistory.ModifiedDate = list.ModifiedDate;
                        taxHistory.Status = EntityStatus.Active;
                        //manually mapped TaxLaw into TaxHistory
                    _taxhistoryrepo.DbSetEntity.Add(taxHistory); // save TaxHistory
                  await  _taxhistoryrepo.DbContext.SaveChangesAsync();
                   await  Task.FromResult(_repository.SingleSave(list)); //here save "list" not obj as you would save whole collection each iteration of the loop
                 }
                trans.Commit();
            }
            return true;
        }
