            DataSet dsSales = OfflineBilling.CreateDatasetFromXML("Salesmaster.xml");
            DataTable dtmaster = dsSales.Tables[0].AsEnumerable().Where(x => x.Field<string>("ReceiptId") == ReceiptId.ToString()).CopyToDataTable();
            DataTable dtitems = dsSales.Tables[1].AsEnumerable().Where(x => x.Field<string>("ReceiptId") == ReceiptId.ToString()).CopyToDataTable();
            var query = from d in dtmaster.AsEnumerable()
                        join c in dtitems.AsEnumerable() on d.Field<string>("ReceiptId") equals c.Field<string>("ReceiptId")
                        .Select(m => new
                        {
                            ReceiptId = d.Field<string>("ReceiptId")
                        });
