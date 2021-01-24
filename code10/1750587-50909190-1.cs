    for (int row = 11; row <= stats.EndRowIndex; ++row)
    {
        try
        {
            priceobj = new NumberRates();
            priceobj.destination = sl.GetCellValueAsString(row, 1);
            priceobj.a_price = sl.GetCellValueAsDecimal(row, 3);
            aPriceList.Add(priceobj);
            DataRow[] match = dTable.Select("Description = '" + priceobj.destination + "'");
            if(match.Length > 0)
               priceobj.Number = match[0].Number;
        }
    }
