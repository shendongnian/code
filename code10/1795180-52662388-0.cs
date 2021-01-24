    public class GetFilesTreeList
    {
        private static List<Files> files = new List<Files>();
        public static void Main(string[] args)
        {
            var path = @"C:\Users\Lukasz\Desktop";
            files.Add(new Files(Path.GetFileName(path), 0));
            WriteFilesRec(path, 1);
            foreach (var filese in files)
            {
                Console.WriteLine(filese);
            }
        }
        
        public class Files {
            public int column;
            public string name;
            public Files(string name, int column)
            {
                this.column = column;
                this.name = name;
            }
            public override string ToString()
            {
                return new String('+', column) + name; 
            }
        }
        public static void WriteFilesRec(string path, int i) {
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach(var d in directory.GetDirectories()) {
                files.Add(new Files(d.Name, i));
                WriteFilesRec(Path.Combine(path, d.Name), i+1);
            }
            foreach(var f in directory.GetFiles()) {
                files.Add(new Files(f.Name, i));
            }
        }
    }
