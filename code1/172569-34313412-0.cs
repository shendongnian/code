     //example
               var  distinctValues =  DetailedBreakDown_Table.AsEnumerable().Select(r => new
                {
                    InvestmentVehicleID = r.Field<string>("InvestmentVehicleID"),
                    Universe = r.Field<string>("Universe"),
                    AsOfDate = _imqDate,
                    Ticker = "",
                    Cusip = "",
                    PortfolioDate = r.Field<DateTime>("PortfolioDate")
    
                } ).Distinct();
