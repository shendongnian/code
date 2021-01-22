    private static readonly Regex MultipleWhitespaceRegex = new Regex(
        @"\s+", 
        RegexOptions.Compiled);
    
    static void Main(string[] args)
    {
        string test = "regex  select    all multiple     whitespace   chars";
    
        const int Iterations = 15000;
    
        var sw = new Stopwatch();
    
        sw.Start();
        for (int i = 0; i < Iterations; i++)
        {
            NormalizeWhitespace(test);
        }
        sw.Stop();
        Console.WriteLine("{0}ms", sw.ElapsedMilliseconds);
    
        sw.Reset();
    
        sw.Start();
        for (int i = 0; i < Iterations; i++)
        {
            MultipleWhitespaceRegex.Replace(test, " ");
        }
        sw.Stop();
        Console.WriteLine("{0}ms", sw.ElapsedMilliseconds);
    }
