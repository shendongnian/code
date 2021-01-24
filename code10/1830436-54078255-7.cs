    using System;
    using System.IO;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    
    
    
    using System.Collections;
    
    
    using Newtonsoft.Json;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    
    namespace Program
    {
        class Program
        {
            public static string last_path = "";
            public static readonly string BYE = "bye";
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
                    string json = JsonConvert.SerializeObject(message);
                    int maxchar = 1024000;
                    if (last_path != "")
                    {
                        long length = new FileInfo(last_path).Length;
                        if (length < maxchar)
                        {
                            maxchar = maxchar - unchecked((int)length);
                            dividefile(last_path, maxchar, json);
                        }
    
                        else
    
                        {
                            dividefile("", maxchar, json);
    
                        }
                    }
                    else
                    {
                        dividefile("", maxchar, json);
    
                    }
    
                }
            }
    
            public static void dividefile(string path, int maxchar, string message)
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
            static void Main(string[] args)
            {
                var producer = Task.Factory.StartNew(() => Producer());
                var consumer = Task.Factory.StartNew(() => Consumer());
                Console.Read();
            }
            class Message
            {
                public int ProductorThreadID { get; set; }
                public int CustomerThreadID { get; set; }
                public string key { get; set; }
                public string content { get; set; }
                public string Name { get; internal set; }
                public int Id { get; internal set; }
    
                public bool endThread()
                {
                    return string.Compare(key, Program.BYE) == 0;
                }
    
                public string ToString(bool isProductor)
                {
                    return string.Format("{0} Thread ID {1} : {2}", isProductor ? "Productor" : "Customer",
                                                                    isProductor ? ProductorThreadID.ToString() : CustomerThreadID.ToString(),
                                                                    content);
                }
            }
        }
    }
