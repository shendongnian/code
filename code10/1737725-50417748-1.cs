    public void Main()
    {
        const int a = 1;
        const int b = 3;
        var t1 = Task.Run(() => new
            {
                c = a + 5
            }
        );
        var t2 = t1.ContinueWith(t =>
            new
            {
                c = t.Result.c,
                d = b + 3
            }
        );
        var t3 = t2.ContinueWith(t =>
            t.Result.c + t.Result.d
        );
        var result = t3.Result;
    }
