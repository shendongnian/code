    public class Result
    {
        private string _StringPart;
        public string StringPart
        {
            get { return _StringPart; }
        }
    
        private int _IntPart;
        public int IntPart
        {
            get { return _IntPart; }
        }
    
        public Result(string stringPart, int intPart)
        {
            _StringPart = stringPart;
            _IntPart = intPart;
        }
    }
    
    class Program
    {
        public static Result GetResult(string source)
        {
            string stringPart = String.Empty;
            int intPart;
            var buffer = new StringBuilder();
            foreach (char c in source)
            {
                if (Char.IsDigit(c))
                {
    	       if (stringPart == String.Empty)
    	       {
                        stringPart = buffer.ToString();
                        buffer.Remove(0, buffer.Length);
                    }
                }
    
                buffer.Append(c);
            }
    
            if (!int.TryParse(buffer.ToString(), out intPart))
            {
                return null;
            }
    
            return new Result(stringPart, intPart);	
        }
    
        static void Main(string[] args)
        {
            Result result = GetResult("OS234");
            Console.WriteLine("String part: {0} int part: {1}", result.StringPart, result.IntPart);
            result = GetResult("AA4230 ");
            Console.WriteLine("String part: {0} int part: {1}", result.StringPart, result.IntPart);
            result = GetResult("ABCD4321");
            Console.WriteLine("String part: {0} int part: {1}", result.StringPart, result.IntPart);
            Console.ReadKey();
        }
    }
