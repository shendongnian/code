new TestRun(1, 1000)
    .AddTransition(new MetaTransition&lt;Input&lt;Vector, Vector&gt;, Vector&gt;
    {
        Name = "Vector Add ",
        Generator = DoubleVectorGenerator,
        Execute = input => input.paramOne.Add(input.paramTwo)
    }
    .RegisterProperty(
        (input, output) =>
            new QnProperty(
                "Is Communative",
                () => QnAssert.IsTrue(output == input.paramTwo.Add(input.paramOne) )
            )
        )
    )
    .Verify()
    .RethrowLastFailureifAny()
    .ReportPropertiesTested(new ConsoleReporter());
