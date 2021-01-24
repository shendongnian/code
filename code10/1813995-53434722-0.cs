    class Program
    {        
        static void Main(string[] args)
        {
            double number = 1.234;
            number = GetDecimalPart(number);
            float number1 = 1.234f;
            number1 = GetDecimalPart(number1);
            decimal number2 = 1.234m;
            number2 = GetDecimalPart(number2);
        }
        private static double GetDecimalPart(double number)
        {
            string strNumber = number.ToString(CultureInfo.InvariantCulture);
            strNumber = strNumber.Substring(strNumber.IndexOf(".") + 1);
            return double.Parse(strNumber);
        }
        private static float GetDecimalPart(float number)
        {
            string strNumber = number.ToString(CultureInfo.InvariantCulture);
            strNumber = strNumber.Substring(strNumber.IndexOf(".") + 1);
            return float.Parse(strNumber);
        }
        private static decimal GetDecimalPart(decimal number)
        {
            string strNumber = number.ToString(CultureInfo.InvariantCulture);
            strNumber = strNumber.Substring(strNumber.IndexOf(".") + 1);
            return decimal.Parse(strNumber);
        }
    }
