     foreach (var list in obj)
     {
       list.CompanyCode = list.CompanyCode;
       list.CummulativeAmount = list.CummulativeAmount;
       list.Percentage = list.Percentage;
       list.ModifiedDate = DateTime.UtcNow;
       list.ModifiedDate = list.ModifiedDate;
       list.Status = EntityStatus.Active;
       _taxhistoryrepo.DbSetEntity.Add(list);
       await  _taxhistoryrepo.DbContext.SaveChangesAsync();
       await  Task.FromResult(_repository.SingleSave(obj));
      }
