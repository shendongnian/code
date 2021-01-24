    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                GetFilesFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Subscribe(
                    file =>
                    {
                        Console.WriteLine(file);
                    });
                var files = await GetFilesFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
                    .ToArray(); // you can also do this
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                Console.ReadLine();
            }).Wait();
        }
        static IObservable<string> GetFilesFromDirectory(string path)
        {
             var files = new Subject<string>();
            var directories = new Subject<string>();
            directories.Select(x => new DirectoryInfo(x)).Subscribe(dir =>
            {
                foreach (var fileInfo in dir.GetFiles())
                {
                    files.OnNext(fileInfo.FullName);
                }
                foreach (var directoryInfo in dir.GetDirectories())
                {
                    directories.OnNext(directoryInfo.FullName);
                }
            }, () =>
            {
                files.OnCompleted();
            });
            Task.Run(() =>
            {
                directories.OnNext(path);
                directories.OnCompleted();
            });
            return files;
        }
