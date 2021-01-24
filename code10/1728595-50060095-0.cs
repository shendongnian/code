    public class Program {
        static string _target = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test", "test.txt");
        static void Main(string[] args) {
            File.Create(_target).Dispose();
            ProcessFile();
            
            // below throws access denied
            if (File.Exists(_target))
                Console.WriteLine(File.ReadAllText(_target));
            Console.ReadKey();
        }
        static void ProcessFile() {
            // open and abandon handle
            var fs = new FileStream(_target, FileMode.Open, FileAccess.Read, FileShare.Delete);
            // delete
            File.Delete(_target);
        }        
    }  
