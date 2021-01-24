    var v = (from cbr in db.Contact_Business_Relation
                     join c in db.Contact on cbr.Contact_No_ equals c.Company_No_
                     join sih in db.Sales_Invoice_Line on sa.No_ equals sih.Document_No_
                     where c.E_Mail == EmailID
    
                     select new ClosedOrders
                     {
                         OrderNumber = sa.Order_No_,
                         Fakturanummer = sih.Document_No_,
                         varnummer = sih.No_,
    
                         //List<string>
                         SerialNoInvoiceOrdrelineDeliveryCloses = db.Item_Ledger_Entry
                         .Where(s => s.Item_No_ == sih.No_)
                         .Select(s => s.Serial_No_)
                         .ToList()
                     }).ToList();
