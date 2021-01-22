        int i;
        int TIMES = 100000;
        Stopwatch sw = new Stopwatch();
        string myPhone = "+1 (123) 123-1234";
        // Using LINQ            
        sw.Start();
        for (i = 0; i < TIMES; i++)
        {
            string StrippedPhone = new string((from c in myPhone
                                               where Char.IsDigit(c)
                                               select c).ToArray());
        }
        sw.Stop();
        Console.WriteLine("Linq took {0}ms", sw.ElapsedMilliseconds);
        // Reset 
        sw.Reset();
        // Using RegEx
        sw.Start();
        for (i = 0; i < TIMES; i++)
        {
            string digits = Regex.Replace(myPhone, @"\D", string.Empty);
        }
        sw.Stop();
        Console.WriteLine("RegEx took {0}ms", sw.ElapsedMilliseconds);
        Console.ReadLine();
