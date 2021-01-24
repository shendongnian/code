    public IEnumerable<PerformaViewModel> LoadByCriteria(string userName = null, string performaName = null, DateTime? invoiceDate = null)
    {
       var query = context.Performas.Where(x => x.IsActive); // Global filter example...
       if (!string.IsNullOrEmpty(userName))
         query = query.Where(x => x.User.UserName == userName);
       if (!string.IsNullOrEmpty(performaName))
         query = query.Where(x => x.PerformaName == performaName);
       if (invoiceDate.HasValue)
         query = query.Where(x => x.InvoiceDate == invoiceDate);
    
      var viewModels = query.Select(x => new PerformaViewModel 
      {
        UserId = x.UserId,
        PerformaName = x.Name,
        UserName = x.User.Name
      }).ToList();
       
      return viewModels;
    }
