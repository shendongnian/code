    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Application {
        class OuterClass {
            int someProperty = 10;
    
            class NestedClass {
                OuterClass reference;
    
                public NestedClass( OuterClass r ) {
                    reference = r;
                }
    
                public void DoSomething( ) {
                    Console.Write( reference.someProperty );
                }
            }
    
            public OuterClass( ) {
                NestedClass nc = new NestedClass( this );
                nc.DoSomething( );
            }
        }
    
        class Test {
            public static void Main( string[] args ) {
                OuterClass oc = new OuterClass( );
            }
        }
    }
