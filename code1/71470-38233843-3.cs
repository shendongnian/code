    [TestClass]
    public class CalculateDerivedPositionUnitTest
    {
        [TestMethod]
        public void OneDegreeSquareAtEquator()
        {
            var center = new GeoCoordinate(0, 0);
            var radius = 111320;
            var southBound = center.CalculateDerivedPosition(radius, -180);
            var westBound = center.CalculateDerivedPosition(radius, -90);
            var eastBound = center.CalculateDerivedPosition(radius, 90);
            var northBound = center.CalculateDerivedPosition(radius, 0);
            Console.Write($"leftBottom: {southBound.Latitude} , {westBound.Longitude} rightTop: {northBound.Latitude} , {eastBound.Longitude}");
        }
    }
