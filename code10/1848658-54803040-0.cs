 csharp
[Binding]
public class Bindings
{
    private ScenarioContext _scenarioContext;
    public Bindings(ScenarioContext scenarioContext)
    {
         _scenarioContext = scenarioContext;
    }
    [AfterScenario]
    public static void AfterScenarioMethod()
    {
        if (_scenarioContext.ScenarioInfo.Tags.Contains("Tag1") &&
            _scenarioContext.ScenarioInfo.Tags.Contains("Tag2") {
            //do you stuff
        }
    }
}
Code is written from memory, I didn't tried it out.
