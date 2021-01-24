        static void Main(string[] args)
    {
        Operator operatorObject = new Operator();
        Console.WriteLine("Pick a number:");
        var val1 = Console.ReadLine();
        int userValue = 0;
        if (val1 != null && val1.Length > 0)
        {
            userValue = Convert.ToInt32(val1);
        }
        Console.WriteLine("Pick another number--optional");
        var val2 = Console.ReadLine();
        int userValue = 0;
        int userValue2 = 0;
        if (val2 != null && val2.Length > 0)
        {
            userValue2 = Convert.ToInt32(val2);
        }
    
    
        int result = operatorObject.operate(userValue, userValue2);
    
        Console.WriteLine(result);
        Console.ReadLine();
    }
    public class Operator
    {
        public int operate(int data, int input = 4)
        {
            return data + input;
        }
    }
