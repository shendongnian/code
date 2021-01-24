            static void Main(string[] args)
            {
                Console.Write("Enter the directory containing files: ");
                var path = Console.ReadLine();
                string[] files = Directory.GetFiles(path);
                byte[] temp = new byte[4];
                foreach (string file in files)
                {
                    byte[] buffer = File.ReadAllBytes(file);
                    for (int i = 0; i < buffer.Count(); i += 4)
                    {
                        temp[0] = buffer[i + 3];
                        temp[1] = buffer[i + 2];
                        temp[2] = buffer[i + 1];
                        temp[3] = buffer[i];
                        Array.Copy(temp, 0, buffer, i, 4);
     
                    }
                    File.WriteAllBytes(file, buffer);
                }
                Console.ReadLine();
            }
