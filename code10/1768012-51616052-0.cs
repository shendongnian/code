    public class MyBindingClass
    {
      private ScenarioContext scenarioContext;
    
      public MyBindingClass(ScenarioContext scenarioContext)
      {
        this.scenarioContext = scenarioContext;
      }
    
      [When("I say hello to ScenarioContext")]
      public void WhenISayHello()
      {
        // access scenarioContext here
      }
    }
