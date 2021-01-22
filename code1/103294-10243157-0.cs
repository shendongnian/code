    static List<Region> GetTerritoriesWithRegions()
        {
            using (NorthwindEntities entities = new NorthwindEntities())
            {
                entities.Territories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return entities.Territories.Include("Region").ToList();
            }
        }
