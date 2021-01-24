    static void Main(string[] args)
            {
                string fileContents = "";
                int encryptKey = 3;
                using (FileStream fs = File.OpenRead(@"C:\Users\My\Desktop\testfile.txt"))
                using (TextReader tr = new StreamReader(fs))
                {
                    fileContents = tr.ReadToEnd();
                }
                byte[] asciiBytesOfFile = Encoding.ASCII.GetBytes(fileContents);
                int[] encrytedContents = Encrypt(encryptKey, asciiBytesOfFile);
            }
    
            private static int[] Encrypt(int encryptKey, byte[] asciiBytesOfFile)
            {
                int[] encryptedChars = new int[asciiBytesOfFile.Length];
                for (int i = 0; i < asciiBytesOfFile.Length; i++)
                {
                    encryptedChars[i] = encryptKey ^ asciiBytesOfFile[i];
                }
                return encryptedChars;
            }
