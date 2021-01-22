    List<SomeClass> convertedList = baseList.ToList();
    convertedList.ForEach(sc =>
    {
        SomeOtherClass oc = someData.First(obj => obj.SomeCode == sc.MyCode);
        if (oc != null)
        {
            sc.SomeData += oc.DataIWantToConcatenate;
        }
    });
    
    baseList = convertedList.AsQueryable(); // back to IQueryable
