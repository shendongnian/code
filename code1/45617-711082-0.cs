    public class Foo:IFoo
    {    
         void IFoo.DoA()
         {
              DoACore();
         }
         void IFoo.DoB()
         {
              DoBCore();
         }
         protected virtual void DoACore()
         {
         }
         protected virtual void DoBCore()
         {
         }
    }
    public class Bar:Foo
    {     protected override void DoACore()
          {
              base.DoACore();
          }
          protected override void DoBCore()
          {
              base.DoBCore();
          }
    }
