    public interface IOperation
    {
        string OutputDirection { get; set; }   
    };
    
    public class MyOperation: IOperation
    {
        public string OutputDirection { get; set; }
    }   
    
    public static class EvalExample
    {
    
        public static T Eval<T>( string direction ) where T : IOperation
        {
                T target = (T) Activator.CreateInstance( typeof( T ) );
    
                target.OutputDirection = direction;
    
                return target; 
        }
    
        // Example only
        public static void Usage()
        {
    
            MyOperation mv = Eval<MyOperation>( "Horizontal" );
    
            Console.WriteLine( mv.OutputDirection ); // Horizontal
        }
    
    }
