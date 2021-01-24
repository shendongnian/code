    public double GetPositiveDouble()
    {
        double result;
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Wert ist ungültig! Bitte erneut versuchen.");
        }
        return result;
    }
