                byte[] password = Encoding.ASCII.GetBytes("password");
                byte[] salt = new byte[] { 0x78, 0x57, 0x8e, 0x5a, 0x5d, 0x63, 0xcb, 0x06};
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(
                    password, salt, "SHA1", 1000);
                byte[] key = pdb.GetBytes(8);
                byte[] iv = pdb.GetBytes(8);
                Console.Out.Write("Key: ");
                foreach (byte b in key)
                {
                    Console.Out.Write("{0:x} ", b);
                }
                Console.Out.WriteLine();
                Console.Out.Write("IV: ");
                foreach (byte b in iv)
                {
                    Console.Out.Write("{0:x} ", b);
                }
                Console.Out.WriteLine();
