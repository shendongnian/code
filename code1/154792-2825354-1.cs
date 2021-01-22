    class Squarer : ITransformer
    {
       public int Transform (int x) { return x * x; }
    }
    class Cuber : ITransformer
    {
       public int Transform (int x) {return x * x * x; }
    }
    ...
    static void Main()
    {
       int[] values = { 1, 2, 3 };
       Util.TransformAll (values, new Cuber());
       foreach (int i in values)
       Console.WriteLine (i);
    }
