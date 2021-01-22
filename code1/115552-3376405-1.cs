    class StrategyA : Strategy
    {
     public override void DoSomething(Parameters parameters)
     {
          //  Now use ObjectA
          if(parameters.ObjectA.SomeProperty == true)
          { ... }
     }
    }
