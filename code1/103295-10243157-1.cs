       List<Territories> territoriesWithRegions = GetTerritoriesWithRegions();
            Territories territory = territories.Where(n => n.TerritoryID == "01581").FirstOrDefault();
            territory.TerritoryDescription = "Hello World";
            Region region = territories.Where(p => p.Any(q => q.Region.RegionID == 2)).FirstOrDefault().Region;
            territory.Region = region;
    
            SaveEntity(territory);
