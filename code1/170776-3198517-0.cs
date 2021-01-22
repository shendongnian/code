    Class Locals
    {
    public static List<Locals> MyLocals = new List<Locals>(); // first thing i add
    Hashtable l = new Hastable();
    void Locals()
    {
        // This will actually be loaded from a DB at runtime.
        l.add(1, "Local 1");
        l.add(2, "Local 2");
        MyLocals.Add(this); // second thing i ass
    }
 
