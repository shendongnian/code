    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class TestBase {
      public int Val;
      public virtual int GetMin() {
        return Val;
      }
    }
    public abstract class Test<T> : TestBase where T : TestBase {
      public List<T> Tests;
      public override int GetMin() {
        return Math.Min(Val, Tests.Select(t => t.GetMin()).Min());
      }
    }
    public class Test1 : Test<Test2> {
    }
    public class Test2 : Test<Test3> {
    }
    public class Test3 : Test<Test4> {
    }
    public class Test4 : TestBase {
    }
