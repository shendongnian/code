    var _adminctrl = new Moq.Mock<AdminController>(); //AdminController is my MVC controller
                
    var mock = new Mock<ControllerContext>();
    mock.Object.Controller = _adminctrl.Object;
    mock.Setup(p => p.HttpContext.Session["UserInfoKey"]).Returns(new ViewModel());
     //here is the catch, attaching the ControllerContext to your controller
    _adminctrl.Object.ControllerContext = mock.Object;
