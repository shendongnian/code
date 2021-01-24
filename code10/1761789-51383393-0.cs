    void Main()
    {
        var result = (from e in Employees
            join o in Orders on e.EmployeeID equals o.EmployeeID
            join d in OrderDetails on o.OrderID equals d.OrderID
            where o.OrderID == 10250
            group new { e, o, d } by new 
            {
                 e.EmployeeID, e.FirstName, e.LastName, e.Address
            }
            into grp select new   
            {
                Name = grp.Key.FirstName + " " + grp.Key.LastName,
                Address = grp.Key.Address,
                SalesTotal = grp.Sum(x => x.d.UnitPrice * x.d.Quantity)
            });
    
            result.Dump();       
    }
