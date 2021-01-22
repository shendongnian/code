    enum Constants
    {
        Abc = 1,
        Def = 2,
        Ghi = 3
    }
    ...
    int i = (int)Enum.Parse(typeof(Constants), "Def");
