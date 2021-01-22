        public void TestCleanSpeed()
        {
            var start = DateTime.Now;
            for (var i = 0; i < 10000; i++)
            {
                string[] tests = {
                                     "{http://company.com/Services/Types}ModifiedAt",
                                     "{http://company.com/Services/Types}CreatedAt"
                                 };
                foreach (var test in tests)
                {
                    Console.WriteLine(Clean(test));
                }
            }
            var end = DateTime.Now;
            var ts = end - start;
            Console.WriteLine(ts);
        }
