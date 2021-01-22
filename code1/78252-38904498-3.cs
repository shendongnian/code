    public static void Main(string[] args)
    {
        var testStr1 = "Apple Banana";
        var testStr2 = @"\\some\long\path\with\lots\of\things\to\escape\some\long\path\t\with\lots\of\n\things\to\escape\some\long\path\with\lots\of\""things\to\escape\some\long\path\with\lots""\of\things\to\escape";
        foreach (var testStr in new[] { testStr1, testStr2 })
        {
            var results = new Dictionary<string,List<long>>();
            
            for (var n = 0; n < 10; n++)
            {
                var count = 1000 * 1000;
                var sw = Stopwatch.StartNew();
                for (var i = 0; i < count; i++)
                {
                    var s = System.Web.HttpUtility.JavaScriptStringEncode(testStr);
                }
                var t = sw.ElapsedMilliseconds;
                results.GetOrCreate("System.Web.HttpUtility.JavaScriptStringEncode").Add(t);
                sw = Stopwatch.StartNew();
                for (var i = 0; i < count; i++)
                {
                    var s = System.Web.Helpers.Json.Encode(testStr);
                }
                t = sw.ElapsedMilliseconds;
                results.GetOrCreate("System.Web.Helpers.Json.Encode").Add(t);
                sw = Stopwatch.StartNew();
                for (var i = 0; i < count; i++)
                {
                    var s = Newtonsoft.Json.JsonConvert.ToString(testStr);
                }
                t = sw.ElapsedMilliseconds;
                results.GetOrCreate("Newtonsoft.Json.JsonConvert.ToString").Add(t);
                
                sw = Stopwatch.StartNew();
                for (var i = 0; i < count; i++)
                {
                    var s = cleanForJSON(testStr);
                }
                t = sw.ElapsedMilliseconds;
                results.GetOrCreate("Clive Paterson").Add(t);
            }
            Console.WriteLine(testStr);
            foreach (var result in results)
            {
                Console.WriteLine(result.Key + ": " + Math.Round(result.Value.Skip(1).Average()) + "ms");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
