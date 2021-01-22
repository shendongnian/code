    private void Test()
    {
        test v1 = new test();
        v1.Id = 12;
        test v2 = new test();
        v2.Id = 12;
        test v3 = new test();
        v3.Id = 12;
        List<test> arr = new List<test>();
        arr.Add(v1);
        arr.Add(v2);
        arr.Add(v3);
        test max = arr.OrderByDescending(t => t.Id).First();
    }
    class test
    {
        public int Id { get; set; }
    }
