    class Init {
        public void Run() {
            StandardKernel kernel = new StandardKernel( new MyLoader() );
            kernel.Get<Tester>( new ConstructorArgument[] { 
                new ConstructorArgument( "ClassName", 
                    this.GetType().Name 
                ) 
            } );            
        }
    }
    public class Tester {
        public Tester(string ClassName) {
            Console.WriteLine("Called From {0}", ClassName);
        }
    }
