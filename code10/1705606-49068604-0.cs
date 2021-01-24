    Pipeline pipeline = runspace.CreatePipeline();    
    string scriptFile = Path.Combine(ScriptDir, scriptpath);
    Command scriptCommand = new Command(scriptFile);
    CommandParameter commandParm = new CommandParameter("name", "value");
    scriptCommand.Parameters.Add(commandParm);
    pipeline.Commands.Add(scriptCommand);
    pipeline.Invoke()
