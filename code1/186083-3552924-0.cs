        static void Main(string[] args)
        {
            string password = "Mypassword";
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            //or byte[] data = System.Text.Encoding.Unicode.GetBytes(password);
            byte[] result;
            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            result = sha.ComputeHash(data);
            Console.WriteLine(Convert.ToBase64String(result));
            Console.ReadLine();
        }
