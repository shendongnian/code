    var unkownSegments = grouped.Where(x => x.ActivityType == null);
    
    foreach (var group in unkownSegments)
    {
       var tempLists = new List<List<LocationResult>>();
       //This variable keeps track of the beginning of the next range
       var rangeStart = 0;
       for (int i = 0; i < group.Items.Count - 1; i++)
       {
          var point1 = group.Items[i];
          var point2 = group.Items[i + 1];
    
          var sCoord = new GeoCoordinate(point1.Lat, point1.Long);
          var eCoord = new GeoCoordinate(point2.Lat, point2.Long);
    
          var distance = sCoord.GetDistanceTo(eCoord);
    
          if(distance > 30)
          {
             var tempList = group.Items.GetRange(rangeStart, i - rangeStart + 1);
             tempLists.Add(tempList);
             rangeStart = i + 1;//Next range will begin on the following item
          }
       }
       if (group.Items.Count - rangeStart > 0)
       {
          //Add all remainging (not added yet) points as the last range.
          var tempList = group.Items.GetRange(rangeStart, group.Items.Count - rangeStart);
          tempLists.Add(tempList);
       }
    }
