            var list = new[] { 1, 2, 3, 4 };
            var result = list.Select(
                    o => new
                    {
                        A = o % 2 == 1 ? o : (int?)null,
                        B = o % 2 == 0 ? o : (int?)null
                    })
                .GroupBy(o => o.A != null)
                .Select(o => o.Select(t => t.A ?? t.B ?? 0).ToList())
                .ToArray();
            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
