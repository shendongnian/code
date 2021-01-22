    static readonly Regex binary = new Regex("^[01]{1,32}$", RegexOptions.Compiled);
    static void Main() {
        Test("");
        Test("01101");
        Test("123");
        Test("0110101101010110101010101010001010100011010100101010");
    }
    static void Test(string s) {
        if (binary.IsMatch(s)) {
            Console.WriteLine(Convert.ToInt32(s, 2));
        } else {
            Console.WriteLine("invalid: " + s);
        }
    }
