    using System;
    using System.Text;
    using System.Globalization;
    using System.Threading;
    
    public class MyClass
    {
        public static void Main()
        {
            Console.WriteLine(ToLongString(1.23e-2));            
            Console.WriteLine(ToLongString(1.234e-5));           // 0.00010234
            Console.WriteLine(ToLongString(1.2345E-10));         // 0.00000001002345
            Console.WriteLine(ToLongString(1.23456E-20));        // 0.00000000000000000100023456
            Console.WriteLine(ToLongString(5E-20));
            Console.WriteLine("");
            Console.WriteLine(ToLongString(1.23E+2));            // 123
            Console.WriteLine(ToLongString(1.234e5));            // 1023400
            Console.WriteLine(ToLongString(1.2345E10));          // 1002345000000
            Console.WriteLine(ToLongString(-7.576E-05));         // -0.00007576
            Console.WriteLine(ToLongString(1.23456e20));
            Console.WriteLine(ToLongString(5e+20));
            Console.WriteLine("");
            Console.WriteLine(ToLongString(9.1093822E-31));        // mass of an electron
            Console.WriteLine(ToLongString(5.9736e24));            // mass of the earth 
    
            Console.ReadLine();
        }
        
        private static string ToLongString(double input)
        {
            string str = input.ToString().ToUpper();
            
            // if string representation was collapsed from scientific notation, just return it:
            if (!str.Contains("E")) return str;
            
            bool negativeNumber = false;
            if (str[0] == '-')
            {
                str = str.Remove(0, 1);
                negativeNumber = true;
            }
            
            string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            char decSeparator = sep.ToCharArray()[0];
            
            string[] exponentParts = str.Split('E');
            string[] decimalParts = exponentParts[0].Split(decSeparator);
            
            // fix missing decimal point:
            if (decimalParts.Length==1) decimalParts = new string[]{exponentParts[0],"0"};
            
            int exponentValue = int.Parse(exponentParts[1]);
            
            string newNumber = decimalParts[0] + decimalParts[1];
            
            string result;
            
            if (exponentValue > 0)
            {
                result = 
                    newNumber + 
                    GetZeros(exponentValue - decimalParts[1].Length);
            }
            else // negative exponent
            {
                result = 
                    "0" + 
                    decSeparator + 
                    GetZeros(exponentValue + decimalParts[0].Length) + 
                    newNumber;
                
                result = result.TrimEnd('0');
            }
            if (negativeNumber)
                result = "-" + result;
            
            return result;
        }
        
        private static string GetZeros(int zeroCount)
        {
            if (zeroCount < 0) 
                zeroCount = Math.Abs(zeroCount);
            
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < zeroCount; i++) sb.Append("0");    
            
            return sb.ToString();
        }
    }
