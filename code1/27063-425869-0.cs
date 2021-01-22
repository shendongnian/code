    class Program
    {
        static void Main(string[] args)
        {
            long phoneNumber = 12345678901234;
            string phoneNumberString = String.Format("{0:(000) 000-0000 x0000}", phoneNumber);
            Console.WriteLine(phoneNumberString);
        }
    }
