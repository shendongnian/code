    static void Main(string[] args)
    {
        Console.WriteLine("Enter number(s): ");
        string input = "";
        List<double> doubleList = new List<double>();
        while (input != "q")
        {
            input = Console.ReadLine();
            if(input != "q")
            {
                try
                {
                    doubleList.Add(Convert.ToInt32(input));
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        average(doubleList);
        Console.ReadKey();
    }
    static void average(List<double> myList)
    {
        double sum = 0;
        Console.Write("You have entered: ")
        foreach (int element in myList)
        {
            sum += element;
            Console.Write(element + ", ");
        }
        Console.WriteLine("");
        double avg = sum / myList.Count;
        Console.WriteLine("The average is: " + avg);
    }
