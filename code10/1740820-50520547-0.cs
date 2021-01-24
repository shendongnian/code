        interface ITest1
        {
            void Test();
        }
        interface ITest2
        {
            void Test();
        }
        public class TestImpl : ITest1, ITest2
        {
            void ITest1.Test()
            {
                
            }
            void ITest2.Test()
            {
                
            }
        }
