    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            controller.injectContext();
            // controller.injectContext(ajaxRequest: true);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
    public static class MvcTestExtensions
    {
        public static void injectContext(this ControllerBase controller, bool ajaxRequest = false)
        {
            var fakeContext = new Mock<ControllerContext>();
            fakeContext.Setup(r => r.HttpContext.Request["X-Requested-With"])
                .Returns(ajaxRequest ? "XMLHttpRequest" : "");
            controller.ControllerContext = fakeContext.Object;
        }
    }
