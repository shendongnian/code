        [TestMethod]
        public void test_sum_stringchars()
        {
            string tmp = "foobar5";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 686
            Console.WriteLine("Value = " + ToGuidKey(tmp));
            // 79ceeb8d
            tmp = "foobar6";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 687
            Console.WriteLine("Value = " + ToGuidKey(tmp));
            // f1f08c51
            tmp = "goobar5";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 687
            Console.WriteLine("Value = " + ToGuidKey(tmp));
            // f7da9f42
            tmp = "foocar5";
            Console.WriteLine("Value = " + tmp.ToCharArray().Sum(x => x));
            // 687
            Console.WriteLine("Value = " + ToGuidKey(tmp));
            // 7698c7ec
        }
        public static Guid ToGuid(string src)
        {
            byte[] stringbytes = System.Text.Encoding.UTF8.GetBytes(src);
            byte[] hashedBytes = new System.Security.Cryptography
                .SHA1CryptoServiceProvider()
                .ComputeHash(stringbytes);
            Array.Resize(ref hashedBytes, 16);
            return new Guid(hashedBytes);
        }
        public static string ToGuidKey(string src)
        {
            return ToGuid(src).ToString().Split('-').First();
        }
