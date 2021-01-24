    List<SalesViewModel> list = (from i in db.Inventories
                        join o in db.SalesOrders on i.OrderId equals o.IID
                        join c in db.CustomerSuppliers on i.SLCode equals c.IID
                        join p in db.SalesPersons on o.SalesPerson equals p.IID into ps
                        from p in ps.DefaultIfEmpty()
                        where i.IID == id
                        select new SalesViewModel
                        {
                            IID = i.IID,
                            DocNo = i.DocNo,
                            DocDt = i.DocDt,
                            RefNo = i.RefNo,
                            RefDate = i.RefDate,
                            DocType = type,
                            DocDesc = i.DocDesc,
                            SLCode = i.SLCode,
                            OrderId = o.OrderId,
                            ClientName = c.Name,
                            SalesPerson = p.Name
                        }).ToList();
