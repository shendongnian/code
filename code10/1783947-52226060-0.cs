        [TestMethod]
        public void test_sum_stringchars()
        {
            string tmp = "foobar5";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 686
            tmp = "foobar6";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 687
            tmp = "goobar5";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 687
            tmp = "foocar5";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 687
        }
