    foreach (object item in crmUpdate)
    {
        // the item reference is of type `object`, cast it to CrmPartPrice
        var partPrice = (CrmPartPrice)item; 
        var row = insertDt.NewRow();
        row["Company"] = partPrice.Company;
        row["Contractid"] = partPrice.Contractid;
        // more of the same...
        insertDt.Rows.Add(row);             
    }
