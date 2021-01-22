        public static void Main(string[] args)
        {
            List<string> arrHeaders = new List<string>();
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder objFolder;
            objFolder = shell.NameSpace(@"C:\temp\testprop");
            for( int i = 0; i < short.MaxValue; i++ )
            {
                string header = objFolder.GetDetailsOf(null, i);
                if (String.IsNullOrEmpty(header))
                    break;
                arrHeaders.Add(header);
            }
            foreach(Shell32.FolderItem2 item in objFolder.Items())
            {
                for (int i = 0; i < arrHeaders.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}: {2}", i, arrHeaders[i], objFolder.GetDetailsOf(item, i));
                }
            }
        }
