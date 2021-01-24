    public int MultiplyFoo(int id, int id2)
    {
        return LocalBar(id, id2);
        int LocalBar(int number, int number2)
        {
            return number * number2 * 2;
        }
    }
    public int MultiplyBar(int id, int id2)
    {
        return LocalBar();
        int LocalBar()
        {
            return id * id2 * 2;
        }
    }
    [Fact]
    public void By_Passing_Id()
    {
        var sut = new LocalFunctions();
        var watch = Stopwatch.StartNew();
        for (int i = 0; i < 10000; i++)
        {
            sut.MultiplyFoo(i, i);
        }
        _output.WriteLine($"Elapsed: {watch.ElapsedTicks}");
    }
    [Fact]
    public void By_Not_Passing_Id()
    {
        var sut = new LocalFunctions();
        var watch = Stopwatch.StartNew();
        for (int i = 0; i < 10000; i++)
        {
            sut.MultiplyBar(i, i);
        }
        _output.WriteLine($"Elapsed: {watch.ElapsedTicks}");
    }
