     private static Dictionary<string , double > GetCoordinate
                        (List<PointK> points, Func<Point, double> selector) 
        { 
            var invertedDictResult = new Dictionary<string, double>(); 
            foreach (var point in points) 
            { 
                if (!invertedDictResult.ContainsKey(point.Mark)) 
                { 
                    invertedDictResult.Add(point.Mark, Math.Round(selector(point), 4)); 
                } 
     
            } 
     
            return invertedDictResult; 
        } 
