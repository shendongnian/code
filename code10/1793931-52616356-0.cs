    class Program
    {
        static void Main(string[] args)
        {
            Operator operatorObject = new Operator();
            Console.WriteLine("Pick a number:");
            int userValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pick another number--optional");
            var userValue2IsValid = int.TryParse(Console.ReadLine(), out int userValue2);
    
            int result = 0;
            if (userValue2IsValid) {
                result = operatorObject.operate(userValue, userValue2);
            }
            else {
                result = operatorObject.operate(userValue);
            }
    
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
