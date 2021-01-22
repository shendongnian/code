    class Program
    {        
        static void Main(String[] args)
        {
            var sb = new StringBuilder();
            var length = 0L;
            var totalRead = 0L;
            var count = 1024; 
                 
            using (var sr = new StreamReader(@"C:\Temp\file.txt"))
            {
                length = sr.BaseStream.Length;               
                while (count > 0)
                {
                    var buffer = new Char[1024];
                    count = sr.Read(buffer, 0, 1024);
                    sb.Append(buffer, 0, count);
                    totalRead += count;
                }                
            }
            
            Console.ReadKey();
        }
    }
