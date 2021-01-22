    class StrategyA : Strategy
    {
         public override void DoSomething(Dictionary<string, object>parameters)
         {
              //  Now use ObjectA
              var someProperty = (bool)parameters["SomeProperty"];
              if() ...
         }
    }
