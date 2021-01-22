    public IEnumerable<TestListViewItemClass> GetItems()
    {
        for (int x = 0; x < 65000; x++)
        {
            yield return new TestListViewItemClass()
            {
                TestDateTime = DateTime.Now,
                TestTimeSpan = TimeSpan.FromDays(x),
                TestInt = new Random(DateTime.Now.Millisecond).Next(),
                TestDecimal = (decimal)x + new Random(DateTime.Now.Millisecond).Next(),
                TestString = "Test string " + x,
            };
        }
    }
