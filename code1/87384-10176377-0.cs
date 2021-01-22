    class Program
    {
        public static void Main(string[] args)
        {
            int i;
            byte bRandom;
            String sL;
            for (i = 0; i < 10; i++)
            {
                bRandom = GetRandom();
                sL = string.Format("Random Number: {0}", bRandom);
                Console.WriteLine(sL);
             }
            Console.ReadLine();
        }
        public static byte GetRandom()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            // Create a byte array to hold the random value.
            byte[] randomNumber = new byte[1];
            rngCsp.GetBytes(randomNumber);
            return randomNumber[0];
        }
    }
