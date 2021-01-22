    var q = Db.Select.From<TInvoiceHeader>()
    	.Where(TInvoiceHeaderTable.custidColumn)
    	.In(Db.SelectColumns(TAccountAssociationTable.custidColumn)
                 .From<TAccountAssociation>()
                 .Where(TAccountAssociationTable.usernameColumn)
                 .IsEqualTo("a")
    	);
    
    List<TInvoiceHeader> collection = q.ExecuteTypedList<TInvoiceHeader>();
