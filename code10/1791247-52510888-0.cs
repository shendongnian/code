    public interface IMyClass {
       void SampleMethod();
    }
    
    public class MyClass : IMyClass
    {
        ILoginTokenKeyApi _loginTokenKeyApi;
        public MyClass(ILoginTokenKeyApi loginTokenKeyApi)
        {
            _loginTokenKeyApi = loginTokenKeyApi;
        }
        public void SampleMethod()
        {
            // method logic goes here...
            var xx = _loginTokenKeyApi.WhatEver;
        }
    }
