    var orders = context.ORDERSUBHEADs.Select(o => 
       new Record[] {
          new Record { SubHeading = o, EdpNo = o.EDPNOS_001, Price = o.EXTPRICES_001, Quantity = o.ITEMQTYS_001 },
          new Record { SubHeading = o, EdpNo = o.EDPNOS_002, Price = o.EXTPRICES_002, Quantity = o.ITEMQTYS_002 },
          new Record { SubHeading = o, EdpNo = o.EDPNOS_003, Price = o.EXTPRICES_003, Quantity = o.ITEMQTYS_003 }
       }
    );
    IEnumerable allOrders = IEnumerable.Empty;
    foreach(Record[] r in orders)
        allOrders = allOrders.Concat(r);
    IEnumerable allRecords = allOrders.Cast<Record>();
