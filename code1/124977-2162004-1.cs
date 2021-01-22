    class Program
    {        
        static void Main(String[] args)
        {
            const int bufferSize = 1024;
            var sb = new StringBuilder();
            var buffer = new Char[bufferSize];
            var length = 0L;
            var totalRead = 0L;
            var count = bufferSize; 
                 
            using (var sr = new StreamReader(@"C:\Temp\file.txt"))
            {
                length = sr.BaseStream.Length;               
                while (count > 0)
                {                    
                    count = sr.Read(buffer, 0, bufferSize);
                    sb.Append(buffer, 0, count);
                    totalRead += count;
                }                
            }
            
            Console.ReadKey();
        }
    }
