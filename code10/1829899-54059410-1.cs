    class Class1 : ISeries {
    int val;
    public void Setstart (int a) {
        val = a;
    }
    public int GetNext () {
        return ++val;
    }
    public void Reset () {
        val = 0;
    }
    static void Main () {
        Class1 c = new Class1();
        c.Setstart(2);
        Console.WriteLine (c.GetNext());
        c.Reset();
        Console.WriteLine ("");
    }
}
