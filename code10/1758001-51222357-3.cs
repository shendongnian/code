    class Program
        {
            static void Main(string[] args)
            {
                var data = new List<string>() { "bill", "david", "john", "daviddd" };
                Func<string, bool> A = value => value.StartsWith("d"); 
        
                var test2 = data.DoWhere(A);       
            }
        }
