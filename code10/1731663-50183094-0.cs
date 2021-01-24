    else if (db.GSDDistricts.Any(x => x.Code == code && x.Area.Disjoint(gsdDistrict.Area)))
    {
        var district = db.GSDDistricts.FirstOrDefault(x => x.Code == code);
        Program.LogWithGreenConsoleColour($"Adding another area for {district.Name}");
        district.Area = district.Area.Union(gsdDistrict.Area);
        db.SaveChanges();                      
    }
