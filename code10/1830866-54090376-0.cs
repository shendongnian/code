    class MyRowThing {
        public int Year {get;set;}
        public decimal Percentage {get;set;}
    }
    var rawData = con.Query<MyRowThing>("SpCountryData",
        new { // params here
            act = "getInflationByYearData", Country,
           startYear = StartYear, endYear = EndYear
        }, commandType: CommandType.StoredProcedure).AsList();
    // now loop over rawData, which is a List<MyRowThing> with the data
