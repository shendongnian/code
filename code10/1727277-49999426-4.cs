        public class Method3Result { public int Value { get; set; } }
        public class X
        {
            private Method3Result method3Result = new Method3Result();
            public void Method1()
            {
                Method2();
                //process result from method3Result
            }
            public void Method2()
            {
                Method3();
            }
            public void Method3()
            {
                method3Result.Value = 3;
            }
        }
