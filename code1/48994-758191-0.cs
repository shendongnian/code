        [TestMethod]
        public void HomeControllerReturnsIndexViewWhenUserIsAdmin() {
            var homeController = new HomeController();
            var userMock = new Mock<IPrincipal>();
            userMock.Expect(p => p.IsInRole("admin")).Returns(true);
            var contextMock = new Mock<HttpContextBase>();
            contextMock.ExpectGet(ctx => ctx.User)
                       .Returns(userMock.Object);
            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.ExpectGet(con => con.HttpContext)
                                 .Returns(contextMock.Object);
            homeController.ControllerContext = controllerContextMock.Object;
            var result = homeController.Index();
            userMock.Verify(p => p.IsInRole("admin"));
            Assert.AreEqual(((ViewResult)result).ViewName, "Index");
        }
