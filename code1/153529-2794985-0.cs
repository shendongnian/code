    class Program
    {
        static void Main(string[] args)
        {
            Directory
                .GetFiles(args[0], "*txt")
                .ToList()
                .ForEach(oldFile => {
                    var newFile = Path.Combine(
                        Path.GetDirectoryName(oldFile), 
                        "New " + Path.GetFileName(oldFile)
                    );
                    File.Move(oldFile, newFile);
                });
            Console.ReadKey();
        }
    }
