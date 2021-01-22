    static void ArrayCompare(IComparable[] Old, IComparable[] New)
    {
        int lpOld = 0;
        int lpNew = 0;
        int OldLength = Old.Length;
        int NewLength = New.Length;
        while (lpOld < OldLength || lpNew < NewLength)
        {
            int compare;
            if (lpOld >= OldLength) compare = 1;
            else if (lpNew >= NewLength) compare = -1;
            else compare = Old[lpOld].CompareTo(New[lpNew]);
            if (compare < 0)
            {
                Debug.WriteLine(string.Format("[Removed] {0}", Old[lpOld].ToString()));
                lpOld++;
            }
            else if (compare > 0)
            {
                Debug.WriteLine(string.Format("[Added] {0}", New[lpNew].ToString()));
                lpNew++;
            }
            else
            {
                Debug.WriteLine(string.Format("[Same] {0}", Old[lpOld].ToString()));
                lpOld++;
                lpNew++;
            }
        }
    }
    static void ArrayCompare2(IComparable[] Old, IComparable[] New) {
        var diff = New.Except( Old );
        var inter = New.Intersect( Old );
        var rem = Old.Except(New);
        foreach (var s in diff)
        {
            Debug.WriteLine("Added " + s);
        }
        foreach (var s in inter)
        {
            Debug.WriteLine("Same " + s);
        }
        foreach (var s in rem)
        {
            Debug.WriteLine("Removed " + s);
        }
    }
    static void Main(string[] args)
    {
        String[] Foo_Old = {"test1", "test2", "test3"};
        String[] Foo_New = {"test1", "test2", "test4", "test5"};
        String[] Bar_Old = {"test1", "test2", "test4"};
        String[] Bar_New = {"test1", "test3"};
        Stopwatch w1 = new Stopwatch();
        w1.Start();
        for (int lp = 0; lp < 10000; lp++)
        {
            ArrayCompare(Foo_Old, Foo_New);
            ArrayCompare(Bar_Old, Bar_New);
        }
        w1.Stop();
        Stopwatch w2 = new Stopwatch();
        w2.Start();
        for (int lp = 0; lp < 10000; lp++)
        {
            ArrayCompare2(Foo_Old, Foo_New);
            ArrayCompare2(Bar_Old, Bar_New);
        }
        w2.Stop();
        Debug.WriteLine(w1.Elapsed.ToString());
        Debug.WriteLine(w2.Elapsed.ToString());
    }
