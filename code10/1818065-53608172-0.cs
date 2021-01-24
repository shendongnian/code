       public List<ControlTowerCity> GetControlTowerMapData(bool IsHub)
        {
           if(isHub)
           {
            using (var context = new LadingControlTowerEntities())
            {
                var mapcityDetail =
                (from SLD in context.ShipmentLocations 
                 join CMD in context.CityMasters on SLD.City equals CMD.ID
    
                 select new ControlTowerCity
                 { 
                     Name = CMD.Name,
    
                 }).ToList();
                return mapcityDetail;
            }
          }
         else
          {
             // other part of query with different join
          }
        }
