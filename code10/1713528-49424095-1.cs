     DataTable dt = new DataTable();
    
                DataColumn[] dcCol =  {
                    new DataColumn("id",typeof(int)),
                    new DataColumn("tid", typeof(int)),
                    new DataColumn("code", typeof(int)),
                    new DataColumn("pNameLocal", typeof(string)),
                    new DataColumn("qty", typeof(int)),
                    new DataColumn("price", typeof(decimal))
            };
    
                dt.Columns.AddRange(dcCol);
                
    
                dt.Rows.Add(1, 101, 101, "some_local_name", 2, 20.36);
                dt.Rows.Add(2, 102, 202, "some_local_name", 1, 10.00);
                dt.Rows.Add(3, 102, 202, "some_local_name", 1, 15.30);
                dt.Rows.Add(4, 102, 202, "some_local_name", 1, 10.00);
                dt.Rows.Add(5, 102, 202, "some_local_name", 2, 15.30);
                dt.Rows.Add(6, 102, 202, "some_local_name2", 1, 15.30);
                dt.Rows.Add(7, 103, 202, "some_local_name", 1, 15.30);
                dt.Rows.Add(8, 104, 65, "some_local_name", 5, 05.00);
                dt.Rows.Add(9, 105, 700, "some_local_name", 2, 07.01);
    
    
                var dtnew = from r in dt.AsEnumerable()
                            group r by new
                            {
                                tid = r.Field<int>("tid"),
                                code = r.Field<int>("code"),
                                pNameLocal = r.Field<string>("pNameLocal"),
                                qty = r.Field<int>("qty"),
                                price = r.Field<decimal>("price")
                            } into grp
                            select new
                            {
                                tid1 = grp.Key.tid,
                                code1 = grp.Key.code,
                                pNameLocal1 = grp.Key.pNameLocal,
                                SumQty = grp.Sum(r => grp.Key.qty),
                                sumPrice = grp.Sum(r => grp.Key.price)
                            };
