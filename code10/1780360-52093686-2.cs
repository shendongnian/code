    DateTime date1 = DateTime.ParseExact(txtDate1.Text, "yyyy/MM/dd hh:mm:ss", CultureInfo.InvariantCulture);
    DateTime date2 = DateTime.ParseExact(txtDate2.Text, "yyyy/MM/dd hh:mm:ss", CultureInfo.InvariantCulture);
    
    var showFamily = (from b in database.tbl_kharidnaghdi
                      join u in database.tbl_Customer on b.CustomerID_FK equals u.CustomerID
                      join c in database.tbl_User on u.UserID_FK equals c.UserID
                      orderby b.KharidnaghdiID descending
                      where u.UserID_FK == userid
                      && txtFamily.Text.Contains(u.Family)
                      && b.Date.CompareTo(date1.Date) <= 0 // date comparison here
                      && b.Date.CompareTo(date2.Date) >= 0
                      select new
                      {
                          u.Name,
                          u.Family,
                          u.Mobile,
                          u.Price,
                          u.CustomerID,
                          b.KharidnaghdiID,
                          b.EtebarHadiye,
                          b.Cashier,
                          b.Date,
                      }).ToList();
