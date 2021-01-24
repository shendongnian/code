    class Program
    {
        static void Main(string[] args)
        {
            GetFilesFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Subscribe(
                file =>
                {
                    Console.WriteLine(file);
                });
             var files = GetFilesFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
                .ToEnumerable(); // you can also do this
            Console.ReadLine();
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
