    public void TestMethod()
    {
        var first = new List<int> {1, 2, 3, 4, 5};
        var second = new List<string> {"One", "Two", "Three", "Four", "Five"};
    
        foreach(var value in this.Zip(first, second, (x, y) => new {Number = x, Text = y}))
        {
            Console.WriteLine("{0} - {1}",value.Number, value.Text);
        }
    }
    
    public IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(List<TFirst> first, List<TSecond> second, Func<TFirst, TSecond, TResult> selector)
    {
        if (first.Count != second.Count)
            throw new Exception();  
    
        for(var i = 0; i < first.Count; i++)
        {
            yield return selector.Invoke(first[i], second[i]);
        }
    }
