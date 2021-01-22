    private static IEnumerable<string> Generate(int count)
        {
            var cripto = new RNGCryptoServiceProvider();
            Func<string> getString = () => new string(
                Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 13)
                    .Select(s =>
                    {
                        var cryptoResult = new byte[4];
                        cripto.GetBytes(cryptoResult);
                        return s[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(s.Length)];
                    })
                    .ToArray());
            var list = new ConcurrentBag<string>();
            var x = Parallel.For(0, count, o => list.Add(getString()));
            return list;
        }
        private static void Test()
        {
            var list = Generate(10000000);
            var list1 = list.ToList();
            var forceListEval = list1.SingleOrDefault(o => o == "0123456789012");
            if (forceListEval != "sdsdf")
            {
                var s = string.Empty;
                var start1 = DateTime.Now;
                if (!list1.Any(o => o == "0123456789012"))
                {
                    var end1 = DateTime.Now;
                    s += " Any: " + end1.Subtract(start1);
                }
                var start2 = DateTime.Now;
                if (!list1.Exists(o => o == "0123456789012"))
                {
                    var end2 = DateTime.Now;
                    s += " Exists: " + end2.Subtract(start2);
                }
                if (!s.Contains("sdfsd"))
                {
                }
            }
