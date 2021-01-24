     static void Main(string[] args)
            {
                var fs = new FileStream(@"file.bin", FileMode.Open);
                var b = new byte[fs.Length];
                var data = fs.Read(b, 0, (int)fs.Length);
                var concatenatedData = new List<string>();
                var temp = string.Empty;
                var processedData = new Dictionary<int, string>();
                var offSet = 0;
                for (int x = 0; x < fs.Length; x ++)
                {
                    if (b[x] == 32 || b[x] == 10 || b[x] == 13)
                        continue;
                    if (b[x] == 48)
                    {
                        if ((x + 1) < fs.Length && b[x + 1] == 48)
                        {
                            if (!string.IsNullOrEmpty(temp))
                                processedData.Add(offSet, temp);
                            temp = string.Empty;
                            x++;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(temp))
                                offSet = x;
                            temp += ((char)b[x]).ToString();
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(temp))
                            offSet = x;
                        temp += ((char)b[x]).ToString();
                    }
                }
                if (!string.IsNullOrEmpty(temp))
                    processedData.Add(offSet , temp);
    
                
    
                Console.ReadLine();
            }
