                string rand = "yiyiuyiyuiyi";
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(rand);
                BitArray b = new BitArray(bytes);
                
                int[] numbers = new int [b.Count];
                
                for(int i = 0; i<b.Count ; i++)
                {
                    numbers[i] = b[i] ? 1 : 0;
                    Console.WriteLine(b[i] + " - " + numbers[i]);
                }
