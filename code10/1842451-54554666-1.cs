    public static class CommonLogicExtensions
    {
       public static DoSomething(this IEnumerable<ICommonLogic> input)
       {
            foreach(var v in input)
            {
                byte[] data = v.Data;
                string name = v.Name;
            }
       }
    }
