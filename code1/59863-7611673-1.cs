    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SharpTestsEx;
    
    namespace DynamicInvokeVsInvoke.Tests
    {
       [TestClass]
       public class DynamicInvokeVsInvokeTests
       {
          [TestMethod]
          public void Call_strategy_with_dynamic_invoke_can_be_catched()
          {
             bool catched = false;
             try
             {
                new StrategiesProvider().CallStrategyWithDynamicInvoke(StrategyTypes.NoWay);
             }
             catch(NotSupportedException exc)
             {
                /* Fails because the NotSupportedException is wrapped
                 * inside a TargetInvokationException! */
                catched = true;
             }
             catched.Should().Be(true);
          }
    
          [TestMethod]
          public void Call_strategy_with_invoke_can_be_catched()
          {
             bool catched = false;
             try
             {
                new StrategiesProvider().CallStrategyWithInvoke(StrategyTypes.NoWay);
             }
             catch(NotSupportedException exc)
             {
                catched = true;
             }
             catched.Should().Be(true);
          }
       }
    }
