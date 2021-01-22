    private const char FirstHebChar = (char)1488; //א
    private const char LastHebChar = (char)1514; //ת
    private static bool IsHebrew(this char c)
    {
         return c >= FirstHebChar && c <= LastHebChar;
    }
