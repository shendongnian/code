    //Extension Method
    
        public static class MoqExtensions
        {
            public static void Callback<T1, T2, T3, T4, T5>(this ICallback iCallBack, Action<T1, T2, T3, T4, T5> action)
            {
            }
        }
    
    //Your class and interface
            
            public interface IMyClass
            {
                void Method(string arg1, string arg2, string arg3, string arg4, string arg5);
            }
    
            public class MyClass : IMyClass
            {
                public void Method(string arg1, string arg2, string arg3, string arg4, string arg5)
                {
                    //Do something
                }
            }
    
    //Your test
    
            [TestMethod]
            public void ExampleTest()
            {
                Mock<IMyClass> mockMyClass = new Mock<IMyClass>();
                mockMyClass.Setup(s => s.Method(It.IsAny<string>(),
                                                It.IsAny<string>(),
                                                It.IsAny<string>(),
                                                It.IsAny<string>(),
                                                It.IsAny<string>()))
                    .Callback<string, string, string, string, string>((string arg1, string arg2, string arg3, string arg4, string arg5) 
                        => { /* Run your mock here */ });
            }
