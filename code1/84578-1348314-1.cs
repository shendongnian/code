    public class PropertyChangedInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //Pseudo code
            if (invocation.Method is Property Setter)
            {
                Call FirePropertyChanged of invocation.InvocationTarget ;
            }
        }
    }
