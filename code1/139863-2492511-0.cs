    // Arrange
    ListController controller = new ListController(domain);
    // Act
    Result actual = controller.DefaultAction();
    // Assert
    MethodCallExpression methodExpr = (MethodCallExpression)actual.NextAction.Body;
    NewExpression newExpr = (NewExpression)methodExpr.Object;
    Assert.That(newExpr.Type, Is.EqualTo(typeof(ProductsController)));
    Assert.That(methodExpr.Method.Name, Is.EqualTo("ListAction"));
