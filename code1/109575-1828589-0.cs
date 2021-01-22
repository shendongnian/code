    private enum Measure { Top, Average, Poor }
    
    private Measure Classify(int nUnits)
    {
       if      (nUnits >= 30000) return Measure.Top;
       else if (nUnits >= 10000) return Measure.Average;
       else return Measure.Poor;
    }
    
    /* ... */
    var years = new int[] { 2008, 2009 };
    var salesByMeasure =
        AnaList.Where(a => years.Contains(a.Year))
               .ToLookup(a => Classify(a.NumberOfUnitsSold));
    var topSales = salesByMeasure[Measure.Top]; // e.g.
