    public IEnumerable<Orders> LoadData()
    {
        var ctx = new DbContext();
        var query = (from o in ctx.tblOrders.AsQueryable()
                     select new Orders
                     {
                         ID = o.OrderID,
                         OrderNum = o.OrderNum.ToString(),
                         Status = o.OrderStatus,
                         Date = o.OrderDate
                     });
        if(CmbOrderStatus.SelectedItems != null)
        {
            List<string> list = new List<string>();
            foreach (SelectedItems obj in CmbOrderStatus.SelectedItems)
            {
                list.Add(obj.ToString());
            }
            query = query.Where(p => list.Contains(p.Status));            
        }
        return query.ToList();
    }
