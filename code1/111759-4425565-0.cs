            //I have created datatable Address having AddressID<int32>,Name-srting,LastName-string
            DataSet ds= new DataSet();
            ds.Tables["Address"].Rows.Add(new object[] { 1, "Priya", "Patel" });
            ds.Tables["Address"].Rows.Add(new object[] { 2, "Bunty", "Rayapati" });
            ds.Tables["Address"].Rows.Add(new object[] { 3, "Birva", "Parikh" });
            //i have created Datatable AddressType having AddressTypeID int32 and State- string
            ds.Tables["AddressType"].Rows.Add(new object[] { 1, "Virginia" });
            ds.Tables["AddressType"].Rows.Add(new object[] { 2, "Nebraska" });
            ds.Tables["AddressType"].Rows.Add(new object[] { 3, "Philadeplhia" });
                
            DataTable dt1 = ds.Address.CopyToDataTable(); 
            DataTable dt2 = ds.AddressType.CopyToDataTable();
            DataTable dt3 = new DataTable();
            var query = dt1.AsEnumerable().Join(dt2.AsEnumerable(),
                dmt1 => dmt1.Field<Int32>("AddressID"),
                    dmt2 => dmt2.Field<Int32>("AddressTypeID"),
            (dmt1, dmt2) => new 
            {
                Table1ID = dmt1.Field<Int32>("AddressID")
                //Other parameters commented out to simplify the example
            });
            query.ToList();
            //FullAddress is my third Datatable is having AID
            foreach (var row in query)
            {
                var r = ds.FullAddress.NewRow();
                r["AID"] = row.Table1ID;
                ds.FullAddress.Rows.Add(r.ItemArray);
                              
            }
