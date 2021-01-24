    public static void Main()
    {
        //Test loop
        string[] testData = { "1234567890", "4444444444", "7777777777", "77777777", "BRADLEYPAU" };
        foreach (string NHSNumber in testData)
        {
            if (isNHSValid(NHSNumber)) //note, no need compare with true
            {
                Console.WriteLine(NHSNumber + " looks good");
            }
            else
            {
                Console.WriteLine(NHSNumber + " is invalid!");
            }
            Console.WriteLine();
        }
    }
