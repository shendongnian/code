    public class DerivedClass : BaseClass
    {
        // Methods
        public DerivedClass()
        {
            MethodExecutionEventArgs ~laosEventArgs~1;
            try
            {
                ~laosEventArgs~1 = new MethodExecutionEventArgs(<>AspectsImplementationDetails_1.~targetMethod~1, this, null);
                <>AspectsImplementationDetails_1.MyTest.OnExceptionWriteAspect~1.OnEntry(~laosEventArgs~1);
                if (~laosEventArgs~1.FlowBehavior != FlowBehavior.Return)
                {
                    <>AspectsImplementationDetails_1.MyTest.OnExceptionWriteAspect~1.OnSuccess(~laosEventArgs~1);
                }
            }
            catch (Exception ~exception~0)
            {
                ~laosEventArgs~1.Exception = ~exception~0;
                <>AspectsImplementationDetails_1.MyTest.OnExceptionWriteAspect~1.OnException(~laosEventArgs~1);
                switch (~laosEventArgs~1.FlowBehavior)
                {
                    case FlowBehavior.Continue:
                    case FlowBehavior.Return:
                        return;
                }
                throw;
            }
            finally
            {
                <>AspectsImplementationDetails_1.MyTest.OnExceptionWriteAspect~1.OnExit(~laosEventArgs~1);
            }
        }
    }
    public BaseClass()
    {
        throw new Exception();
    }
 
