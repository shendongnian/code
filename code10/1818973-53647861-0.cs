    public async Task<bool> SaveOrUpdate(IEnumerable<TaxLaw> taxLawList)
        {
            using (var trans = _taxhistoryrepo.DbContext.Database.BeginTransaction())
            {
                foreach (var taxLaw in taxLawList)
                {
                    var taxTableHisory = new TaxTableHisory();
                    taxTableHisory.CompanyCode = taxLaw.CompanyCode;
                    taxTableHisory.CummulativeAmount = taxLaw.CummulativeAmount;
                    taxTableHisory.Percentage = taxLaw.Percentage;
                    taxTableHisory.ModifiedDate = taxLaw.ModifiedDate;
                    taxTableHisory.Status = EntityStatus.Active;
    
                    _taxhistoryrepo.DbSetEntity.Add(taxTableHisory);
                    await _taxhistoryrepo.DbContext.SaveChangesAsync();
                }
                trans.Commit();
            }
            return true;
        }
