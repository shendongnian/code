 CSharp
private static void TestLevels(ArgProcessor incomingProcessor)
{
    Action<ProcessorLevel, int> currentLevelIteration = null;
    currentLevelIteration = (currentProcessor, currentLevel) =>
    {
        currentProcessor.CurrentLevel.ShouldBeEquivalentTo(currentLevel);
        ProcessorLevel nextProcessor = currentProcessor.CurrentProcessor;
        if (nextProcessor != null)
            currentLevelIteration(nextProcessor, currentLevel + 1);
    };
    
    currentLevelIteration(incomingProcessor, 0);
}
[Theory]
[InlineData(typeof(Build), "Build")]
public void ProcessorType(Type ProcessorType, params string[] args)
{
    ArgProcessor newCLI = new OriWeb_CLI.ArgProcessor(args);
    IncomingArgumentsTests.TestLevels(newCLI);
    
    newCLI.CurrentProcessor.ShouldBeOfType(ProcessorType);
}
[Theory]
[InlineData(typeof(Build.TypeScript), "TypeScript")]
[InlineData(typeof(Build.CSharp), "CSharp")]
public void BuildProcessors(Type ProcessorType, params string[] args)
{
    List<string> newArgs = new List<string> {"Build"};
    foreach(string arg in args) newArgs.Add(arg);
    
    ArgProcessor newCLI = new OriWeb_CLI.ArgProcessor(newArgs.ToArray());
    
    IncomingArgumentsTests.TestLevels(newCLI);
    
    newCLI.CurrentProcessor.CurrentProcessor.ShouldBeOfType(ProcessorType);
}
