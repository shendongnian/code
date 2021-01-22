     class Program
        {
            static Nullable<int> f(){ return 4; }        
            static Nullable<int> g(){ return 7; }
            static Nullable<int> h(){ return 9; }
            
    
            static void Main(string[] args)
            {
          
    
                Nullable<int> z = 
                                  f().Bind( fval => 
                                  g().Bind( gval => 
                                  h().Bind( hval =>
                                  new Nullable<int>( fval + gval + hval ))));
    
                Console.WriteLine(
                        "z = {0}", z.HasValue ? z.Value.ToString() : "null" );
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
