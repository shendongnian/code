    [TestFixture]
    public class RouteDataExtensionsTests
    {
        [Test]
        public void GetAreaName_should_return_area_name()
        {
            var routeData = new RouteData();
            routeData.DataTokens.Add("area", "Admin");
            routeData.GetAreaName().ShouldEqual("Admin");
        }
        [Test]
        public void GetAreaName_should_return_null_when_not_set()
        {
            var routeData = new RouteData();
            routeData.GetAreaName().ShouldBeNull();
        }
    }
