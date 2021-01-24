    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReadMemory
    {
        class Program
        {
            public static async Task Main(string[] args)
            {
                string code = "Hello, World";
                var memoryStream = Encoding.UTF8.GetBytes(code.ToCharArray(), 0, code.Length);
                using (var stream = new MemoryStream(memoryStream))
                using (var reader = new StreamReader(stream))
                {
   
                    Memory<char> memory = new Memory<char>(new char[1024]);  // Init with backing buffer. Otherwise you are trying to read 0 bytes into a zero sized buffer. 
                    int charsRead = await reader.ReadAsync(memory);
    
                    Console.WriteLine($"Memory<char> len: {memory.Length}, bytes read: {charsRead}");
                }
    
            }
        }
    }
