      {
                   byte[] result;
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine("test");
                    writer.WriteLine(12);
                    writer.WriteLine(true);
    
                    writer.Flush();
    
                    result = stream.GetBuffer();
                }
    
                using(MemoryStream stream=new MemoryStream(result))
                {
                    StreamReader reader = new StreamReader(stream);
                   while(! reader.EndOfStream)
                     Console.WriteLine(reader.ReadLine());
                   }
                }
