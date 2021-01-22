            int key = 83847; // whatever value you want
            string str = "This is my file";
            // "Encrypt"
            var sb = new StringBuilder(str.Length);
            foreach (var ch in str)
            {
                sb.Append((char)(ch ^ key));
            }
            Console.WriteLine(sb.ToString()); // Garbled text
            // "Decrypt"
            var sbReversed = new StringBuilder(str.Length);
            foreach (var ch in sb.ToString())
            {
                sbReversed.Append((char)(ch ^ key));
            }
            Console.WriteLine(sbReversed.ToString()); // "This is my file"
