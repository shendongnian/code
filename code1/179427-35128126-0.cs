        public static string ReadPassword(char mask)
        {
            const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
            int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const
            
            SecureString securePass = new SecureString();
            char chr = (char)0;
            while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
            {
                if (((chr == BACKSP) || (chr == CTRLBACKSP)) 
                    && (securePass.Length > 0))
                {
                    System.Console.Write("\b \b");
                    securePass.RemoveAt(securePass.Length - 1);
                }
                // Don't append * when length is 0 and backspace is selected
                else if (((chr == BACKSP) || (chr == CTRLBACKSP)) && (securePass.Length == 0))
                {
                }
                // Don't append when a filtered char is detected
                else if (FILTERED.Count(x => chr == x) > 0)
                {
                }
                // Append and write * mask
                else
                {
                    securePass.AppendChar(chr);
                    System.Console.Write(mask);
                }
            }
            System.Console.WriteLine();
            IntPtr ptr = new IntPtr();
            ptr = Marshal.SecureStringToBSTR(securePass);
            string plainPass = Marshal.PtrToStringBSTR(ptr);
            Marshal.ZeroFreeBSTR(ptr);
            return plainPass;
        }
