[Test]
public void TestSomeStuff() {
  var name = "some name";
  var httpContext = new Mock<HttpContext>();
  httpContext.Setup(m => m.User.IsInRole("RoleName")).Returns(true);
  httpContext.Setup(m => m.User.FindFirst(ClaimTypes.Name)).Returns(name);
  var context = new ControllerContext(new ActionContext(httpContext.Object, new RouteData(), new ControllerActionDescriptor());
  var controller = new MyController()
  {
    ControllerContext = context
  };
  var result = controller.Index();
  Assert.That(result, Is.Not.Null);
}
