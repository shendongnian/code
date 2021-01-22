            var result = 1234567
                .ToString()
                .Select((c, index) => new { IndexIsOdd = index % 2 == 1, ValueOfDigit = Char.GetNumericValue(c) })
                .GroupBy(d => d.IndexIsOdd)
                .Select(g => new { OddColumns = g.Key, sum = g.Sum(item => item.ValueOfDigit) });
            foreach( var r in result )
                Console.WriteLine(r);
