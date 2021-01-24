    var greenPoints = 
        allPoints.Except(new[] { redPoint, bluePoint })
                 .Select(p => new Vector(bluePoint, p))
                 .Where(v => {
                     var angle = AngleBetween(v, blueRedVector);
                     return angle > Math.PI / 2 &&
                            angle < 3 * Math.PI / 2; });
