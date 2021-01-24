       class Program
        {
            private static BlockingCollection<Message> messages = new BlockingCollection<Message>();
            private static void Producer()
            {
                int ctr = 1;
                while (true)
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
                    Console.WriteLine(JsonConvert.SerializeObject(message));
        
           
            int length = message.Length;
           //or int length = new System.IO.FileInfo(path).Length; 
           if(length ==1024){
    
                    using (var streamWriter = File.CreateText(Path.Combine(@"C:\TEMP", $"File-{ DateTime.Now.ToString("yyyyMMddHHmmssfff")}.json")))
                    {
                        using (var writer = new JsonTextWriter(streamWriter))
                        {
                            writer.Formatting = Formatting.Indented;
                            writer.WriteStartObject();
                            writer.WritePropertyName("Data");
                            writer.WriteStartArray();
                            writer.WriteRawValue(JsonConvert.SerializeObject(message));
                            writer.WriteEndArray();
                            writer.WriteEndObject();
                        }
                    }
                }}
            }
            static void Main(string[] args)
            {
                var producer = Task.Factory.StartNew(() => Producer());
                var consumer = Task.Factory.StartNew(() => Consumer());
                Console.Read();
            }
        }
