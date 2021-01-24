    var greenPoints = 
        allPoints.Except(new[] { redPoint, bluePoint })
                 .Select(p => new Vector(bluePoint, p))
                 .Where(v => 
                     AngleBetween(v, blueRedVector) > Math.PI / 2 &&
                     AngleBetween(v, blueRedVector) < 3 * Math.PI / 2));
