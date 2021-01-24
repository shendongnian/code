    var intermediate = (from sa in db.tblActionItems
                        join trid in db.tblTripReports on sa.TripReportID equals trid.tripreportID
                        join cust in db.tblCustomers on trid.Customer_ID equals cust.CustomerID
                        join emp in db.tblEmployees on cust.EmployeeID equals emp.EmployeeID
                        select
                         new 
                         {
                             Status = sa.Status,
                             Action_Item = sa.Action_Item,
                             Owners = sa.Owners,
                             Due_Date = sa.Due_Date,
                             Updated = sa.Updated,
                             CreateDate = sa.CreateDate,
                             Sales = emp.Sales
                         }).ToList();
    var result = intermediate.Select(x=> new tblActionItem {
                        Status = x.Status,
                        Action_Item = x.ActionItem,
                       Owners = x.Owners,
                       Due_Date = x.DueDate;
                       Updated =x.Update,
                       CreateDate = x.CreateDate,
                       Sales = x.Sales
        });
