    [TestClass]
    public class NodeHelperTests{
        [TestMethod]
        public void Should_GetNodes_With_Count_GreaterThanZero() {
            //Arrange
            var context = new DefaultHttpContext();
            var session = new TestSession();
            var feature = new BlahSessionFeature();
            feature.Session = session;
            context.Features.Set<ISessionFeature>(feature);
            var accessor = new HttpContextAccessor { HttpContext = context };
            var helper = new NodeHelper(accessor);
            //Act
            var nodes = helper.GetNodes();
            //Assert
            Assert.IsTrue(nodes.Count > 0);            
        }
    }
