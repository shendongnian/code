    class Program
    {
        public void MethodWithParams(object param1, params int[] param2) 
        {            
        }
        static void Main(string[] args)
        {
            var method = typeof(Program).GetMethod("MethodWithParams");
            var @params = method.GetParameters();
            foreach (var param in @params) 
            {
                Console.WriteLine(param.IsDefined(typeof(ParamArrayAttribute), false));
            }
        }
    }
