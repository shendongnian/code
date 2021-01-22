    internal abstract class SecretFunctionWrapper
    {
        private void MySecretFunction()
        {
            ...
        }
        protected void FunctionWhichCalls()
        {
            ...
            MySecretFunction();
        }
    }
   
    public MyRealClass : SecretFunctionWrapper
    {
        ...
    }
