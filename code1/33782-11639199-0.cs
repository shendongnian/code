    var result = Repeat(new { Name = "Foo Bar", Age = 100 }, 10);
    
    private static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
    {
        for(int i=0; i<count; i++)
        {
            yield return element;
        }
    }
