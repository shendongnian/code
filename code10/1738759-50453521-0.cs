    List<YearlySale> YearlySales = new List<YearlySale>() { new YearlySale() { EmpID = 1, Sales = 700, Year = 2018 },
                                                            new YearlySale() { EmpID = 1, Sales = 600, Year = 2017 },
                                                            new YearlySale() { EmpID = 1, Sales = 500, Year = 2016 },
                                                            new YearlySale() { EmpID = 2, Sales = 400, Year = 2018 },
                                                            new YearlySale() { EmpID = 2, Sales = null, Year = 2017 },
                                                            new YearlySale() { EmpID = 2, Sales = 300, Year = 2016 }
                                                            };
    List<SalesTotal> SalesTotals = new List<SalesTotal>() { new SalesTotal() { EmpID = 1, EmpName = "stan", TotalSales  = 1800 },
                                                            new SalesTotal() { EmpID = 2, EmpName = "sally", TotalSales = 700 }
                                                            };
    var q = from s in SalesTotals
            join y18 in YearlySales 
                on s.EmpID equals y18.EmpID
            join y17 in YearlySales
                on s.EmpID equals y17.EmpID
            join y16 in YearlySales
                on s.EmpID equals y16.EmpID
            where y18.Year == 2018
            where y17.Year == 2017
            where y16.Year == 2016
            select new { SalesTotal = s, Year18 = y18 == null ? 0 : y18.Year, YearS18 = y18 == null ? 0 : y18.Sales
                                        , Year17 = y17 == null ? 0 : y17.Year, YearS17 = y17 == null ? 0 : y17.Sales
                                        , Year16 = y16 == null ? 0 : y16.Year, YearS16 = y16 == null ? 0 : y16.Sales
                        };
    foreach (var v in q.OrderBy(x => x.SalesTotal.EmpID))
    {
        Debug.WriteLine($"{v.SalesTotal.EmpID} {v.SalesTotal.EmpName} {v.SalesTotal.TotalSales} {v.YearS18} as y18 {v.YearS17} as y17  {v.YearS16} as y16" );
    }
