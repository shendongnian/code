        [Test]
        public void HomeController_Index_Should_Return_Non_Null_ViewPage()
        {
            // Assign:
            var homeController = new HomeController();
            Mock<ControllerContext> controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.Setup(
                x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("admin")))
                ).Returns(true);
            homeController.ControllerContext = controllerContextMock.Object;
            // Act:
            ActionResult index = homeController.Index();
            // Assert:
            Assert.IsNotNull(index);
            // Place other asserts here...
            controllerContextMock.Verify(
                x => x.HttpContext.User.IsInRole(It.Is<string>(s => s.Equals("admin"))),
                Times.Exactly(1),
                "Must check if user is in role 'admin'");
        }
