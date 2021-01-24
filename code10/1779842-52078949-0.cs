    Expression<Func<Foo, bool>> capturedExpression = null; 
    _fooRepository.Setup(m => m.GetList(It.IsAny<Expression<Func<Foo, bool>>>()))
    .Returns((Expression<Func<Foo, bool>> e ) => { capturedExpression = e; return foos; }); 
    Assert.IsTrue(capturedExpression.Compile()(_foos[1])); 
    Assert.IsFalse(capturedExpression.Compile()(_foos[0]));
