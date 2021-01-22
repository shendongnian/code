    public static String toXDigit(this int inputInteger, int x)
    {
       String xDigitNumber = inputInteger.ToString();
       while (xDigitNumber.Length < x) { xDigitNumber = "0" + xDigitNumber; }
       return xDigitNumber;
    }
