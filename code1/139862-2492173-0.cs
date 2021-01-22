    var result1 = new Result {
        NextAction = new ProductsController(domain).ListAction };
    var result2 = new Result {
        NextAction = new ProductsController(domain).ListAction };
    //objects are different
    Assert.That(result1, Is.Not.EqualTo(result2));
    //delegates are different
    Assert.That(result1.NextAction, Is.Not.EqualTo(result2.NextAction));
    //methods are the same
    Assert.That(result1.NextAction.Method, Is.EqualTo(result2.NextAction.Method));
