    /*
     * This example is written for console application, that can be tested easily.
     * The logic can be rewritten for WinForm
     */
    static void TheFirstCase()
    {
        //This should be replaced by the differents actions you want to do
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
            //If you need parameters in the TheFirstCase(), use new Action<TypeOfTheFirstParam, TypeOfTheSecondParam, ...>(TheFirstCase)
            //If your Method needs to return something, use Func instead of Action
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
