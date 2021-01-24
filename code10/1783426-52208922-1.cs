    public double TmpNumberOne;
    public double TmpNumberTwo;
    public double Add(double x, double y)
    {
        return x + y;
    }     
    public void PrintCalculation(string action)
    {
        switch (action)
        {
            case "Add":
                Console.WriteLine("Sum is: {0}", Add(TmpNumberOne, TmpNumberTwo).ToString());
                break;
        }
    }
