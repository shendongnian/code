    // Customers
    var cust = db.CustomerAccounts.Single(x => x.Email == user.Email);
    
    if (cust != null)
    {
       Session["CustId"] = cust.CustId;
    }
    
    // Admins
    var admin = db.Admins.SingleOrDefault(x => x.Email == admnLogin.Email);
    
    if (admin != null)
    {
       Session["AdminId"] = admin.AdminID;
    }
