    static void Main(string[] args)
    {    
        string decryptedInput = "Hello World!";
        string encryptedOutput = new string(decryptedInput.Select(EncryptChar).ToArray());
        Console.WriteLine(encryptedOutput);
    }
    private static char EncryptChar(char arg)
    {
        return arg;
    }
