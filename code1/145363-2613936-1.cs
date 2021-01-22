        public abstract class ComboFuncBase
        {
            protected Func<string,string> chain = x => x;     // start with identity operation
            // Here are your various functions ... defined as methods or as functions like this ..
            protected Func<string, string> Afunc = input => input + "A";
            protected Func<string, string> Bfunc = input => input + "B";
            protected Func<string, string> Cfunc = input => input + "C";
            /// <summary>
            /// Execute the chain of functions
            /// </summary>
            public string Apply(string argument)
            {
                return chain(argument);
            }
            /// <summary>
            /// Apply FunctionC - always available
            /// </summary>
            public ComboFuncWithC C(string sz)
            {
                return new ComboFuncWithC() { chain = x => Cfunc(chain(x)) };
            }
        }
        /// <summary>
        /// A chain without a C in it yet allows A's and B's
        /// </summary>
        public class ComboFunc : ComboFuncBase
        {
            /// <summary>
            /// Apply FunctionA
            /// </summary>
            public ComboFunc A(string sz)
            {
                return new ComboFunc() { chain = x => Afunc(chain(x)) };
            }
            /// <summary>
            /// Apply FunctionB
            /// </summary>
            public ComboFunc B(string sz)
            {
                return new ComboFunc() { chain = x => Bfunc(chain(x)) };
            }
        }
        /// <summary>
        /// After C has been applied you can't apply A or B
        /// </summary>
        public class ComboFuncWithC : ComboFuncBase
        {
        }
        static void Main(string[] args)
        {
            string input = "hello";
            var combo = new ComboFunc().A(" world").B("!").C(" - see");
            // Intellisense / Compiler will not allow this ...
            //var combo2 = new ComboFuncBase.ComboFunc().A(" world").C("!").B(" - see");
