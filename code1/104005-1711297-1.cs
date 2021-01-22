    public ActionResult Inquiry(string Num, DateTime Date)
    {  ...
       Bill myBill = new Bill(Num, Date, myConnections);      
       //This is where I am trying to store my data...      
       return View("Inquiry", myBill);
    }
    
    public ActionResult Summary(Bill bill)
    {     
       //... do stuff
       return View("Summary", bill);
    }
