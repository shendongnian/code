         class Program
        {
            public static string last_path = "";
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
    
            private static  void Consumer()
            {
                foreach (var message in messages.GetConsumingEnumerable())
                {
                    Console.WriteLine(JsonConvert.SerializeObject(message));
    
                    int maxchar = 10240;
                    if (last_path != "")
                    {
                        long length = new FileInfo(last_path).Length;
                        if (length < maxchar)
                        {
                            maxchar = maxchar - unchecked((int)length);
                            dividefile(last_path, maxchar, message);
                        }
    
                        else
    
                        {
                            dividefile("", maxchar, message);
       
                         }
                    }
                    else
                    {
                        dividefile("", maxchar, message);
    
                     }
    
                }
            }
            static void Main(string[] args)
            {
                var producer = Task.Factory.StartNew(() => Producer());
                var consumer = Task.Factory.StartNew(() => Consumer());
                Console.Read();
            }
    
            public  void dividefile(string path, int maxchar, string message)
            {
    
                //FileStream fileStream = new FileStream(yourfile, FileMode.Open, FileAccess.Read);
                byte[] byteArray = Encoding.UTF8.GetBytes(message);
    
                MemoryStream stream = new MemoryStream(byteArray);
    
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    Int64 x1 = stream.Length;
                    char[] fileContents = new char[maxchar];
                    int charsRead = streamReader.Read(fileContents, 0, maxchar);
    
                    // Can't do much with 0 bytes
                    if (charsRead == 0)
                        throw new Exception("File is 0 bytes");
    
                    while (charsRead > 0)
                    {
                        x1 = x1 - maxchar;
    
                        if (x1 > 0)
                        {
                            string s = new string(fileContents);
                            if (path == "")
                            {
                                last_path = Path.Combine(@"C:\TEMP", $"File-{ DateTime.Now.ToString("yyyyMMddHHmmssfff")}.json");
                                path = "";
                            }
                            else
                            {
                                last_path = path;
                            }
                            using (var streamWriter = File.CreateText(last_path))
                            {
                                using (var writer = new JsonTextWriter(streamWriter))
                                {
                                    writer.Formatting = Formatting.Indented;
                                    writer.WriteStartObject();
                                    writer.WritePropertyName("Data");
                                    writer.WriteStartArray();
                                    writer.WriteRawValue(JsonConvert.SerializeObject(s));
                                    writer.WriteEndArray();
                                    writer.WriteEndObject();
                                }
                            }
    
                            charsRead = streamReader.Read(fileContents, 0, maxchar);
                        }
                        else
                        {
                            int m = (int)(((x1 + maxchar) % maxchar));
                            string messagechunk = new string(fileContents, 0, m);
                            if (path == "")
                            {
                                last_path = Path.Combine(@"C:\TEMP", $"File-{ DateTime.Now.ToString("yyyyMMddHHmmssfff")}.json");
                                path = "";
                            }
                            else
                            {
                                last_path = path;
                            }
                            using (var streamWriter = File.CreateText(last_path))
                            {
                                using (var writer = new JsonTextWriter(streamWriter))
                                {
                                    writer.Formatting = Formatting.Indented;
                                    writer.WriteStartObject();
                                    writer.WritePropertyName("Data");
                                    writer.WriteStartArray();
                                    writer.WriteRawValue(JsonConvert.SerializeObject(messagechunk));
                                    writer.WriteEndArray();
                                    writer.WriteEndObject();
                                }
                            }
    
                            charsRead = streamReader.Read(fileContents, 0, m);
                        }
                    }
                }
    
            }
        
    }
