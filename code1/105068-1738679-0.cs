    class Program
    {
        static void Main(string[] args)
        {
            var search = new FileSearcher().FindFile(@"d:\users", "autofac.dll", f => Console.WriteLine(f.FullName), () => Console.WriteLine("Finished"));
            Console.WriteLine("C - cancel, else - finish");
            for (; ; )
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "C":
                        search.Cancel();
                        break;
                    default:
                        return;
                }
            }
        }
    }
    public class FileSearcher
    {
        public FileSearch FindFile(string searchPath, string fileName, Action<FileInfo> onFileFound, Action onSearchFinished)
        {
            var search = new FileSearch(new DirectoryInfo(searchPath), fileName);
            search.FileFound += onFileFound;
            search.Finished += onSearchFinished;
            search.Run();
            return search;
        }
    }
    public class FileSearch
    {
        readonly BackgroundWorker _worker = new BackgroundWorker();
        readonly DirectoryInfo _searchPath;
        readonly string _template;
        public FileSearch(DirectoryInfo searchPath, string template)
        {
            _searchPath = searchPath;
            _template = template;
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.WorkerSupportsCancellation = true;
        }
        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var directory in GetPartiallyFlatDirectories(_searchPath, 4))
            {
                if (_worker.CancellationPending)
                    break;
                foreach (var file in directory.GetFiles(_template, SearchOption.AllDirectories))
                    FileFound.Raise(file);
            }
        }
        static IEnumerable<DirectoryInfo> GetPartiallyFlatDirectories(DirectoryInfo directory, int flatDepth)
        {
            if (flatDepth == 0)
            {
                yield return directory;
                yield break;
            }
            foreach (var subDir in directory.GetDirectories())
            {
                var flattened = GetPartiallyFlatDirectories(subDir, flatDepth - 1);
                if (!flattened.Any())
                    yield return subDir;
                else
                    foreach (var flatDirectory in flattened)
                        yield return flatDirectory;
            }
        }
        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Finished.Raise();
        }
        public void Cancel()
        {
            _worker.CancelAsync();
        }
        public event Action<FileInfo> FileFound;
        public event Action Finished;
        public void Run()
        {
            _worker.RunWorkerAsync();
        }
    }
    public static class DelegateExtensions
    {
        public static void Raise<T>(this Action<T> action, T obj)
        {
            if (action != null)
                action(obj);
        }
        public static void Raise(this Action action)
        {
            if (action != null)
                action();
        }
    }
