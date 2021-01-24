    static void Main(string[] args)
    {
        string a1 = ".2700 Aqr sh./Tgt sh.";
        string a2 = "USD 2.4700/Tgt sh.";
        var firstStringNums = GetNumbersFromString(ref a1);
        Console.Write("My Text: {0}",a1);
        Console.Write("myNums: ");
        foreach(double a in firstStringNums)
        {
            Console.Write(a +"\t");
        }
        var secondStringNums = GetNumbersFromString(ref a2);
        Console.Write("My Text: {0}", a2);
        Console.Write("myNums: ");
        foreach (double a in secondStringNums)
        {
            Console.Write(a + "\t");
        }
    }
    public static List<double> GetNumbersFromString(ref string input)
    {
        List<double> result = new List<double>();
        Regex r = new Regex("[0-9.,]+");
        var numsFromString = r.Matches(input);
        foreach(Match a in numsFromString)
        {
            if(double.TryParse(a.Value,out double val))
            {
                result.Add(val);
                input =input.Replace(a.Value, "");
            }
        }
        return result;
    }
