        static void HashAndPrint(TextWriter op, string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = ToAnsiiBytes(text);
            byte[] hash = md5.ComputeHash(bytes);
            PrintHash(Console.Out, hash);
            Console.Out.WriteLine( " = {0}", text);
        }
