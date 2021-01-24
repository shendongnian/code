     int[] ar = new[] { 3, 1, 2, 3 };
            var result = ar.GroupBy(x => x) //values groups
            .Select(x => new
            {
                Number = x.Key,
                Count = x.Count()
            }).OrderByDescending(x => x.Count) //Short
            .FirstOrDefault(); //First Result
     result.Count // how many 
     result.Key   // max number
