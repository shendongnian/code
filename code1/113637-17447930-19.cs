    var customersTest = from c in db.Customers
        select new {
            strDate=SqlFunctions.DateName("dd", c.EndDate)
                +"."+SqlFunctions.DateName("mm", c.EndDate)
                +"."+SqlFunctions.DateName("yyyy", c.EndDate) 
        }
