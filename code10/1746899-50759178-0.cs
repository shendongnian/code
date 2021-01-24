    var query = CatTable.Select(ct => new 
    { 
        CatCode = ct.CatCode, 
        CatName = ct.CatName, 
        DogCatCode = !DogTable.Any(dt => dt.CatCode == ct.CatCode && dt.NameCode == "")
    });
