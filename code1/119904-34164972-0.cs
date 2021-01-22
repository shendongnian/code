                StreamReader sr = new StreamReader("H:/kate/rani.txt");
                Console.WriteLine(sr.ReadToEnd());
                
                sr.BaseStream.Position = 0;
             
                Console.WriteLine("----------------------------------");
                
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
