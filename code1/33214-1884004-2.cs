    private static void RunPowershellScript(string scriptFile, string scriptParameters)
    {
        RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
        Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
        runspace.Open();
        RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
        Pipeline pipeline = runspace.CreatePipeline();
        Command scriptCommand = new Command(scriptFile);
        Collection<CommandParameter> commandParameters = new Collection<CommandParameter>();
        foreach (string scriptParameter in scriptParameters.Split(' '))
        {
            CommandParameter commandParm = new CommandParameter(null, scriptParameter);
            commandParameters.Add(commandParm);
            scriptCommand.Parameters.Add(commandParm);
        }
        pipeline.Commands.Add(scriptCommand);
        Collection<PSObject> psObjects;
        psObjects = pipeline.Invoke();
    }
