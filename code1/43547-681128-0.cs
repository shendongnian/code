    Dim qry = From customer in DataContext.Customers
    qry = qry.Where( Function (c as Customer) c.Name="Jim" )
    qry = qry.Where( Function (c as Customer) c.Age < 65 )
    qry = qry.OrderByDescending( Function (c as Customer) c.Age )
    qry = qry.Take(1) 
    Dim oldJim as Customer = qry.FirstOrDefault()
