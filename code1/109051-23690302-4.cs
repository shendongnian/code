    public enum Letters
    {
        None = 0,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H
    }
    [Flags]
    public enum Flavors
    {
        None = 0,
        Cherry = 1,
        Grape = 2,
        Orange = 4,
        Peach = 8
    }
    static void Main(string[] args)
    {
        Flavors flavors = Flavors.Peach;
        Letters letters = flavors.ChangeType<Letters>();
    }
