            FileStream fs = new FileStream(@"c:\text.txt", FileMode.Open);
            var hasher = new MD5CryptoServiceProvider();
            var A = hasher.ComputeHash(fs);
            PrintHash(Console.Out, A);
            Console.Out.WriteLine();
            var salt = new byte[] { 0x53, 0x41, 0x4C, 0x54 };
            var B = hasher.ComputeHash(ToAnsiiBytes("SALT"));
            PrintHash(Console.Out, B);
            Console.Out.WriteLine();
            var m = new MemoryStream(ToAnsiiBytes("SALT"), false);
            fs.Seek(0, SeekOrigin.Begin);
            var ms = new MergedStream(fs, m);
            
            var C = hasher.ComputeHash(ms);
            PrintHash(Console.Out, C);
            Console.Out.WriteLine();
            HashAndPrint(Console.Out, "toto");
            HashAndPrint(Console.Out, "totoSALT");
            HashAndPrint(Console.Out, "SALT");
