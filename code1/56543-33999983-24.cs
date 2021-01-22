     private static void Test()
        {
            var list1 = File.ReadAllLines("test.txt").Take(500000).ToList();
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
        }
