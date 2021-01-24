    private List<double> Income = new List<double>();
    
    public void ListIncome()
    {
        Console.Clear();
        Console.Write("Income: ");
        Income.Add(Convert.ToDouble(Console.ReadLine()));
    }
    
    public void ShowList()
    {
        foreach (double value in Income)
        {
            Console.WriteLine(value);
        }
        Console.ReadKey();
    }
