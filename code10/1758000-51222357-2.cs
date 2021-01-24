     class Program
    {
        static void Main(string[] args)
        {
            var data = new List<string>() { "bill", "david", "john", "daviddd" };
    
    
            var test2 = data.DoWhere(A); //This Line Compile is wrong
        }
    
        public static bool A(string value)
        {
            if (value.StartsWith("d"))
            {
                return true;
            }
            return false;
        } 
    }
