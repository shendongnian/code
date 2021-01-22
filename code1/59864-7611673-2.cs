    using System;
    using System.Collections.Generic;
    
    namespace DynamicInvokeVsInvoke
    {
       public class StrategiesProvider
       {
          private readonly Dictionary<StrategyTypes, Action> strategies;
    
          public StrategiesProvider()
          {
             strategies = new Dictionary<StrategyTypes, Action>
                          {
                             {StrategyTypes.NoWay, () => { throw new NotSupportedException(); }}
                             // more strategies...
                          };
          }
    
          public void CallStrategyWithDynamicInvoke(StrategyTypes strategyType)
          {
             strategies[strategyType].DynamicInvoke();
          }
    
          public void CallStrategyWithInvoke(StrategyTypes strategyType)
          {
             strategies[strategyType].Invoke();
          }
       }
    
       public enum StrategyTypes
       {
          NoWay = 0,
          ThisWay,
          ThatWay
       }
    }
