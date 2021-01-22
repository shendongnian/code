      var collection = new[] {
          new[] {"Oarfish", "Atmosphere", "Pretty " }, 
          new[] {"Raven", "Radiation", "Adorable" },
          new[] {"Sunflower", "Flowers", "Cute" }  
     };
     var fieldCount = 3;
     var maximums = new List<String>(fieldCount);
     for (var i = 0; i < fieldCount; i++)
     {
         maximums.Add(Column(collection, i).OrderByDescending(columnItem => columnItem.Length).First());
     }
