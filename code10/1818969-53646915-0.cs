    public  async Task<bool> SaveOrUpdate(IEnumerable<TaxLaw> obj)
    {
        using (var trans = _taxhistoryrepo.DbContext.Database.BeginTransaction())
        {
            // var lists = new List<TaxTableHistory>();
            foreach (var taxLaw in obj)
            {
                    var taxTableHistory = new TaxTableHistory();
                    taxTableHistory.CompanyCode = taxLaw.CompanyCode;
                    taxTableHistory.CummulativeAmount = taxLaw.CummulativeAmount;
                    taxTableHistory.Percentage = taxLaw.Percentage;
                    taxTableHistory.ModifiedDate = DateTime.UtcNow;
                    taxTableHistory.ModifiedDate = taxLaw.ModifiedDate;
                    taxTableHistory.Status = EntityStatus.Active;
                _taxhistoryrepo.DbSetEntity.Add(taxTableHistory);
                await  _taxhistoryrepo.DbContext.SaveChangesAsync();
                await  Task.FromResult(_repository.SingleSave(obj));
             }
            trans.Commit();
        }
        return true;
    }
