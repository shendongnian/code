    public void Main()
    {
        var result = Calculate(1, 3).Result;
        async Task<int> Calculate(int a, int b)
        {
            var c = await Add(a, 5);
            var d = await Add(b, 3);
            return await Add(c, d);
        }
        async Task<int> Add(int a, int b)
        {
            return a + b;
        }
    }
