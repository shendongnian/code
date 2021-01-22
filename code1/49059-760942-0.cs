    using System;
    using System.Collections.Generic;
    
    namespace LanguageTests2
    {
        public class A { }
    
        public class B : A {}
    
        public class C : B {}
    
        public static class VirtualExtensionMethods
        {
            private static readonly IDictionary<Type,Action<A>> _dispatchMap 
                = new Dictionary<Type, Action<A>>();
    
            static VirtualExtensionMethods()
            {
                _dispatchMap[typeof(A)] = x => ExecuteInternal( (A)x );
                _dispatchMap[typeof(B)] = x => ExecuteInternal( (B)x );
                _dispatchMap[typeof(C)] = x => ExecuteInternal( (C)x );
            }
    
            public static void Execute( this A instance )
            {
                _dispatchMap[instance.GetType()]( instance );
            }
    
            private static void ExecuteInternal( A instance )
            {
                Console.WriteLine("\nCalled ToString() on: " + instance);
            }
    
            private static void ExecuteInternal(B instance)
            {
                Console.WriteLine( "\nCalled ToString() on: " + instance );
            }
    
            private static void ExecuteInternal(C instance)
            {
                Console.WriteLine("\nCalled ToString() on: " + instance);
            }
        }
    
        public class VirtualExtensionsTest
        {
            public static void Main()
            {
                var instanceA = new A();
                var instanceB = new B();
                var instanceC = new C();
    
                instanceA.Execute();
                instanceB.Execute();
                instanceC.Execute();
            }
        }
    }
