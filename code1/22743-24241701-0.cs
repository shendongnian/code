    [TestMethod]
    public void Constructor_FullTest()
    {
    
        IDrawingContext context = new Mock<IDrawingContext>().Object; 
 
        ConstructorTests<Frame>
            .For(typeof(int), typeof(int), typeof(IDrawingContext))
            .Fail(new object[] { -3, 5, context }, typeof(ArgumentException), "Negative  length")
            .Fail(new object[] { 0, 5, context }, typeof(ArgumentException), "Zero length")
            .Fail(new object[] { 5, -3, context }, typeof(ArgumentException), "Negative width")
            .Fail(new object[] { 5, 0, context }, typeof(ArgumentException), "Zero width")
            .Fail(new object[] { 5, 5, null }, typeof(ArgumentNullException), "Null drawing context")
            .Succeed(new object[] { 1, 1, context }, "Small positive length and width")
            .Succeed(new object[] { 3, 4, context }, "Larger positive length and width")
            .Assert();
    
    }
