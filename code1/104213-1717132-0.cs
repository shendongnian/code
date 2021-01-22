    var extension = MockRepository
        .GenerateMock<IContextExtension<StandardContext>>();
      var ctx = new StandardContext();
      ctx.AddExtension(extension);
      extension.AssertWasCalled(
        e=>e.Attach(null), 
        o=>o.Constraints(Is.Equal(ctx)));
