    var totals = Enumerable.Range(0, 10)
        .Select(x => (number / (int)Math.Pow(10, x)) % 10)
        .Where(x => x > 0)
        .Reverse()
        .Select((x, i) => new { Even = x * (i % 2), Odd = x * ((i + 1) % 2) })
        .Aggregate((a, x) => new { Even = a.Even + x.Even, Odd = a.Odd + x.Odd });
    Console.WriteLine(number);         // 1234567
    Console.WriteLine(totals.Even);    // 12
    Console.WriteLine(totals.Odd);     // 16
