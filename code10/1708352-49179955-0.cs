    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Before Execute ");
                Execute();
                Console.WriteLine("After Execute ");
    
                Console.ReadLine();
            }
    
             static async Task Execute()
            {
                Func<Task> myFunc = null;
                myFunc += async () => {
                    Console.WriteLine("in async func");
                    await WriteCharacters();
                };
    
                myFunc += () => {
                    Console.WriteLine("in func");
                    return WriteCharacters();
                };
    
                await myFunc();
            }
    
            static async Task WriteCharacters()
            {
                await Task.Delay(4000);
                using (StreamWriter writer = File.CreateText("newfile.txt"))
                {
                    Console.WriteLine("Writeing the file");
                    await writer.WriteAsync("Example text as string");
                }
            }
        }
    }
