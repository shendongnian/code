            cDoc.DocType.AssignObjectValue(dr["DocType"]);           // int
            cDoc.DocID.AssignObjectValue(dr["docID"]);
            cDoc.CustomerNo.AssignObjectValue(dr["customerNo"]);     // string
            cDoc.InvTitle.AssignObjectValue(dr["InvTitle"]);
            cDoc.TaxPercent.AssignObjectValue(dr["taxPercent"]);     // double
            cDoc.TaxTypeID = GetTaxTypeIDForDocType(cDoc.DocType);
            cDoc.Remarks.AssignObjectValue(dr["remarks"]);
            cDoc.Cost.AssignObjectValue(dr["cost"]);                 // double
            cDoc.InvDate.AssignObjectValue(dr["InvDate"]);           // date
