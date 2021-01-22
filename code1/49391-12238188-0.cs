    public class Program
    {
	    private static void Main(string[] args) {
	       var lambda = Lambda.TransformMethodTo<Func<string, int>>()
				              .From(() => Parse)
				              .ToLambda();            
	    }   
            
        public static int Parse(string value) {
	       return int.Parse(value)
        } 
    }
