    void Main()
    {
        print(0, 100);
    }
    public void print(int x, int limit)
    {
        Console.WriteLine(++x);
        if(x != limit)
            print(x, limit);
    }
