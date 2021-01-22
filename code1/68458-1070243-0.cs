    Expect.Call(object.DoSomething(null, null, null, null)
          .IgnoreArguments() // Ignore those nulls
          .Constraints(Is.Equal("value1"),
                       Property.Value("PropertyA", "value2"),
                       Is.Anything(),
                       Is.Anything())
          .Return(whateverItShouldReturn);
