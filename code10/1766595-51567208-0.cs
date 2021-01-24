    public static OrderedDictionary spellResults = new OrderedDictionary()
    {
        {"Test",new int[]{5,7}}
    };
    static void Main(string[] args)
    {
        int[] pval = ((Array)spellResults["Test"]) as int[];
        Console.WriteLine(pval[0] + "," + pval[1]);
    }
