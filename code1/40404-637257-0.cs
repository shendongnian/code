    public void TestForEach()
        {
            List<string> items = new List<string> { "one", "two", "three" };
            foreach (string item in items)
            {
                Debug.WriteLine(item);
            }
        }
