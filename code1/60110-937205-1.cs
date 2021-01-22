    using System;
    using System.Linq;
    
    namespace DemoApp
    {
        public class TestClass
        {
            private EventHandler _Test;
    
            public event EventHandler Test
            {
                add
                {
                    if (_Test == null || !_Test.GetInvocationList().Contains(value))
                        _Test += value;
                }
    
                remove
                {
                    _Test -= value;
                }
            }
    
            public void OnTest()
            {
                if (_Test != null)
                    _Test(this, EventArgs.Empty);
            }
        }
    
        class Program
        {
            static void Main()
            {
                TestClass tc = new TestClass();
                tc.Test += tc_Test;
                tc.Test += tc_Test;
                tc.OnTest();
                Console.In.ReadLine();
            }
    
            static void tc_Test(object sender, EventArgs e)
            {
                Console.Out.WriteLine("tc_Test called");
            }
        }
    }
