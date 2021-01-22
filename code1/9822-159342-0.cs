    public class BaseClass : SomeOtherBase 
    {
       public BaseClass() {}
       protected virtual void Setup()
       {
       }
    }
    public BaseClassProxy : BaseClass
    {
       bool _fakeOut;
       protected BaseClassProxy(bool fakeOut)
       {
            _fakeOut = fakeOut;
            Setup();
       }
       public override void Setup()
       {
           if(_fakeOut)
           {
                base.Setup();
           }
           //Your other constructor code
       }
    } 
