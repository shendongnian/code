    List<SweetViewModel> allSweets = new List<SweetViewModel>();
    
                var w = (from s in db.Sweets
                         select new SweetViewModel
                         {
                             CategoryID = s.CategoryID,
                             Description = s.Description,
                             Price = s.Price,
                             Qty = 0,
                             SweetID = s.SweetID,
                             SweetName = s.SweetName
                         });
    
                allSweets = w.ToList();
