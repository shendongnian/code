    public static byte[] Digits(int num)
    {
        int nDigits = 1 + Convert.ToInt32(Math.Floor(Math.Log10(num)));
        byte[] digits = new byte[nDigits];
        
        for(int i = nDigits - 1; i != 0; i--)
        {
            digits[i] = (byte)(num % 10);
            num = num / 10;
        }
        return digits;
    } 
