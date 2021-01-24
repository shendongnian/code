    private void button2_Click(object sender, EventArgs e)
        {
            Test.overflow.StringExtensionTest();
            ((string)Test.overflowed).StringExtensionTest();
        }
    public static class Test
    {
        public static string overflow = "Only a test";
        public static dynamic overflowed = "Only a test";
        public static void StringExtensionTest(this string stringer) { MessageBox.Show("This is just a test for stackoverflow"); }
    }
