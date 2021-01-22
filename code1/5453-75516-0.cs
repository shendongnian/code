            using (FileStream fs = new FileStream("c:\file.txt", FileMode.Open))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (System.IO.StreamReader sr = new StreamReader(bs))
                    {
                        string output = sr.ReadToEnd();
                    }
                }
            }
