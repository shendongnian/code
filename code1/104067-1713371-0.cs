    [DllImport("MyDLL.dll", CallingConvention = CallingConvention.StdCall)]
    static extern void printnames(String[] astr, int size);
    List<string> names = new List<string>();
    names.Add("first");
    names.Add("second");
    names.Add("third");
    
    printnames(names.ToArray(), names.Count);
