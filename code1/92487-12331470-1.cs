        static void Main(string[] args)
        {
            Number number1 = new Number(5000);
            DateTime dateTime = DateTime.Now;
            string s = Factorial(number1).ToString();
            TimeSpan timeSpan = DateTime.Now - dateTime;
            long sum = s.Select(c => (long) (c - '0')).Sum();
        }
        static Number Factorial(Number value)
        {
            if( value.ValueCount==1 && value.ValueAsLong==2)
            {
                return value;
            }
            return Factorial(new Number(value.ValueAsLong - 1)) * value;
        }
    }
