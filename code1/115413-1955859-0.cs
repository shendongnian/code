    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            GetBackupFiles(@"c:\temp\backup files");
        }
        static void GetBackupFiles(string path)
        {
            FileInfo[] fileList = new DirectoryInfo(path).GetFiles("*_Drive*.*v2i");
            var results = from file in fileList
                          orderby file.CreationTime
                          select new 
                          {  file.Name
                            ,file.CreationTime
                            ,file.Length 
                            ,IsMainBackup = file.Extension.ToLower() == ".v2i"
                            ,ImageNumber = Regex.Match(file.Name, @"drive([\d]{0,5})", RegexOptions.IgnoreCase).Groups[1]
                            ,IncrementNumber = parseNumber( Regex.Match(file.Name, @"_i([\d]{0,5})\.iv2i", RegexOptions.IgnoreCase).Groups[1])
                          };
            foreach (var x in results)
                Console.WriteLine(x.Name);
        }
        static int? parseNumber(object num)
        {
            int temp;
            if (num != null && int.TryParse(num.ToString(), out temp))
                return temp;
            return null;
        }
    }
