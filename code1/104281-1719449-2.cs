    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;
    
    namespace ConsoleApplication15 {
    
        [global::System.Serializable]
        public class SuperException : Exception {
    
            private void SaveStack() {
                fullTrace = Environment.StackTrace;
            }
    
            public SuperException() { SaveStack(); }
            public SuperException(string message) : base(message) { SaveStack();  }
            public SuperException(string message, Exception inner) : base(message, inner) { SaveStack(); }
            protected SuperException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
    
            private string fullTrace; 
            public override string StackTrace {
                get {
                    return fullTrace;
                }
            }
        }
    
        class Program {
    
            public void ExternalMethod() {
                InternalMethod();
            }
    
            public void InternalMethod() {
                try {
                    ThrowIt();
                } catch (Exception ex) {
                    Console.WriteLine(ex.StackTrace);
                }
            }
    
            [MethodImpl(MethodImplOptions.NoInlining)]
            public void ThrowIt() {
                throw new SuperException();
            }
    
    
            static void Main(string[] args) {
                new Program().ExternalMethod();
                Console.ReadKey();
            }
        }
    }
