    static void Main(string[] args)
        {
            Console.WriteLine("임의의 정수를 입력해주세요");
            int n =Convert.ToInt32(Console.ReadLine());
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("test",MemoryMappedFileRights.Write))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, (long)1e2))
                    {
                        StreamWriter sw = new StreamWriter(stream);
                        while (true)
                        {
                            sw.Write(n + " " );
                            Console.Write(n + " ");
                            if (n == 1) break;
                            if (n % 2 == 0) n /= 2;
                            else n = 3 * n + 1;
                            Thread.Sleep(500);
                        }
                        sw.Flush();  // <---- added
                        Console.WriteLine();
                    }
                }
            }
            catch
            {
                while (true)
                {
                    Console.Write("WHY IT DOESNT WORK????\n");
                    Thread.Sleep(500);
                };
            }
         }
