    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void Index(){
            // Disposizione
            var authMock = new Mock<IAuthenticationProvider>();
            var controller = new HomeController(authMock.Object);
            
            // Azione
            ViewResult result = controller.Index() as ViewResult;
            // Asserzione
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
