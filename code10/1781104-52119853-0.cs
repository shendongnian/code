        class Readfile
        {
            public static void readf()
            {
                Console.WriteLine("Enter sentence : ");
                string str = Console.ReadLine();
                string filename = @"C: \Users\jan31\Desktop\matthew\text.txt";
                Encoding fileEncoding = Encoding.Default;
                bool Found = false;
                using (Stream s = System.IO.File.OpenRead(filename))
                {
                    int current;
                    string ReadText = "";
                    List<Byte> L = new List<Byte>();
                    do
                    {
                        current = s.ReadByte();
                        if (current != -1)
                        {
                            L.Add((Byte)current);
                            ReadText = fileEncoding.GetString(L.ToArray());
                            if (ReadText.Length > str.Length)
                            {
                                L.RemoveAt(0);
                                ReadText = fileEncoding.GetString(L.ToArray());
                            }
                            if (ReadText.Length == str.Length)
                            {
                                if (ReadText == str)
                                {
                                    //Found it ##############
                                    Found = true;
                                }
                            }
                        }
                    } while ((current != -1) && !Found);
                }
                if (!Found) {
                    //Not Found it ##############
                }
            }
        }
