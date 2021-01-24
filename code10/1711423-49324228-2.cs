     public class PermenatEmployee
    {
        public static void SayGoodBye(out string action)
        {
            action = "GoodBye";
           
        }
        private static void Main(string[] args)
        {
            PermenatEmployee.SayGoodBye(out var action);
            Console.WriteLine(action);
        }
    }
