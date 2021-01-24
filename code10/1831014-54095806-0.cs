     class Program
        {
            private static List<Batch> batchList = new List<Batch>();
            private static BlockingCollection<Message> messages = new BlockingCollection<Message>();
        
            private static int maxbatchsize = 240;
            private static int currentsize = 0;
            private static void Producer()
            {
                int ctr = 1;
                while (ctr <= 11)
                {
                    messages.Add(new Message { Id = ctr, Name = $"Name-{ctr}" });
                    Thread.Sleep(1000);
                    ctr++;
                }
            }
        
            private static void Consumer()
            {
                foreach (var message in messages.GetConsumingEnumerable())
                {
                    var msg = JsonConvert.SerializeObject(message);
        
                    Console.WriteLine(msg);
        
                    if (currentsize + msg.Length >= maxbatchsize)
                    {
                          var listToWrite = batchList.Copy();
                          batchList.Clear();
                          currentsize = 0;
                          WriteToFile(listToWrite );
                    }
        
                    batchList.Add(new Batch { Message = message });
                    currentsize += msg.Length;
                }
            }
        
            private static void WriteToFile(List<Batch> listToWrite)
            {
                using (StreamWriter outFile = System.IO.File.CreateText(Path.Combine(@"C:\TEMP", $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.json")))
                {
                 outFile.Write(JsonConvert.SerializeObject(listToWrite));
                }
        
                currentsize = currentsize - listToWrite.Length; 
            }
        
            static void Main(string[] args)
            {
                var producer = Task.Factory.StartNew(() => Producer());
                var consumer = Task.Factory.StartNew(() => Consumer());
                Console.Read();
            }
        }
      }
