    {
        var ArgsToProcess = new List<string> { "arg_one", "arg_two", "arg_three" };
        var delegateArg = new DelegateInArgument<string> { Name = "s" };
        Activity toRun = new ParallelForEach<string>
        {
            Body = new ActivityAction<string>
            {
                Argument = delegateArg,
                Handler = new Workflow1() //Plug your workflow here  
                {
                    Arg = delegateArg
                }
            }
        };
        WorkflowInvoker.Invoke(toRun, new Dictionary<string, object>
            {
                {"Values", ArgsToProcess}
            });
    }
