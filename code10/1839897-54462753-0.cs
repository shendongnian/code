    DataTable finalResults = ( from cus in customers.AsEnumerable()
        join bill in billing.AsEnumerable().DefaultIfEmpty() on  cus.Field<string>("Resp_ID")  equals age.Field<string>("ID")  into cs
        from c in cs.DefaultIfEmpty() 
        select new
        {
            reference_id = cus["CustomerId"],
            family_id = cus["Resp_ID"],
            last_name = cus["LastName"],
            first_name = cus["FirstName"],
            billing_31_60 = c == null ? "0" : c["billing_31_60"],
            billing_61_90 = c == null ? "0" : c["billing_61_90"],
            billing_over_90 = c == null ? "0" : c["billing_over_90"],
            billing_0_30 = c == null ? "0" : c["billing_0_30"]    
        }).CopyToDataTable();
