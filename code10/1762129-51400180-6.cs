    var q = (from s in db.Sweets
                         join c in db.Carts on s.SweetID equals c.SweetID into j
                         from c in j.DefaultIfEmpty()
                         where c.CartID == "7125794e-38f4- 4ec3-b016-cd8393346669"
                         select new SweetViewModel
                         {
                             CategoryID = s.CategoryID,
                             Description = s.Description,
                             Price = s.Price,
                             Qty = c.Qty,
                             SweetID = s.SweetID,
                             SweetName = s.SweetName
                         });
