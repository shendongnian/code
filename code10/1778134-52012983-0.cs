    [TestClass]
    public class MyViewBagTestClass {
        [TestMethod]
        public void TestIndexHasApplicationInsightsKey() {
            // Arrange            
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.AreNotEqual(null,result.ViewBag.InstrumentationKey as string);
        }
    }
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.InstrumentationKey = "Hello world";
            return View("Index");
        }
    }
