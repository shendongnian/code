    static void TheFirstCase()
    {
        Console.WriteLine("first case");
    }
    static void TheSecondtCase()
    {
        Console.WriteLine("second case");
    }
    static void TheThirdCase()
    {
        Console.WriteLine("third case");
    }
    static void Main(string[] args)
    {
        Dictionary<string, Delegate> MyDic = new Dictionary<string, Delegate>
        {
            { "First", new Action(TheFirstCase) },
            { "Second", new Action(TheSecondtCase) },
            { "Third", new Action(TheThirdCase) }
        };
        // in your question, this is e.ColumnIndex
        var ValueInColIndex = 42;
        // in your question, this is dataGridView.Columns
        var DataGridViewDatas = new Dictionary<string, int>
        {
            {  "First", 0 },
            {  "Second", 42 },
            {  "Third", 69 }
        };
        foreach (var MyAction in MyDic)
        {
            if (DataGridViewDatas[MyAction.Key] == ValueInColIndex)
            {
                MyAction.Value.DynamicInvoke();
            }
        }
    }
