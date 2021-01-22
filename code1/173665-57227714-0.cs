            mockDependency
                .CheckMethodWasCalledOnce(nameof(IExampleDependency.PersistThings))
                .WithArg<InThing2>(inThing2 =>
                {
                    Assert.Equal("Input Data with Important additional data", inThing2.Prop1);
                    Assert.Equal("I need a trim", inThing2.Prop2);
                })
                .AndArg<InThing3>(inThing3 =>
                {
                    Assert.Equal("Important Default Value", inThing3.Prop1);
                    Assert.Equal("I NEED TO BE UPPER CASED", inThing3.Prop2);
                });
