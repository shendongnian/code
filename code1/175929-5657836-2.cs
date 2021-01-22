    using System;
    using System.Collections.Generic;
    
    public delegate void MyDelegate<T>( T i );
    
    public class DelegateList<T>
    {
        public void Add( MyDelegate<T> del ) {
            imp.Add( del );
        }
    
        public void CallDelegates( T k ) {
            foreach( MyDelegate<T> del in imp ) {
                del( k );
            }
        }
    
        private List<MyDelegate<T> > imp = new List<MyDelegate<T> >();
    }
    
    public class MainClass
    {
        static void Main() {
            DelegateList<int> delegates = new DelegateList<int>();
    
            delegates.Add( PrintInt );
            delegates.CallDelegates( 42 );
        }
    
        static void PrintInt( int i ) {
            Console.WriteLine( i );
        }
    }
