    _mockClass.Setup(x=>x.MethodToBeMocked().Returns(value)
    .Callback(() => {
        var trace = new System.Diagnostics.StackTrace();
        var callerName = trace.GetFrame(5).GetMethod().Name;
        if (callerName == "Foo") CallFromFooMethod++;
        if (callerName == "Bar") CallFromBarMethod++;
    });
