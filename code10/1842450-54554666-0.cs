    public void DoSomething<T>(List<T> input) where T : ICommonLogic
    {
        foreach(var v in input)
        {
            byte[] data = v.Data;
            string name = v.Name;
        }
    }
