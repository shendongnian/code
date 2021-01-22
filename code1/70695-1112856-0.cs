    using System;
    using System.Globalization;
    public class StrToInt {
    	public static void Main(string[] args) {
            string val = "FF";
            int num = Int32.Parse(val, NumberStyles.AllowHexSpecifier);
            Console.WriteLine(num);
    	}
    }
