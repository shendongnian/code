      class Program
        {
            static void Main(string[] args)
            {
                var tr = typeof(TestReflection);
                
                var ctr = tr.GetConstructor( 
                    BindingFlags.NonPublic | 
                    BindingFlags.Instance,
                    null, new Type[0], null);
    
                var obj = ctr.Invoke(null);
    
                ((TestReflection)obj).DoThatThang();
    
                Console.ReadLine();
            }
        }
    
        class TestReflection
        {
            internal TestReflection( )
            {
                
            }
    
            public void DoThatThang()
            {
                Console.WriteLine("Done!") ;
            }
        }
