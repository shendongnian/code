        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Update();
            Application.Run(new Form1());
        }
        private static void Update()
        {
            string mainFolder;
            string updateFolder;
            string backupFolder;
            foreach (string file in
                System.IO.Directory.GetFiles(updateFolder))
            {
                string newFile = file.Replace(
                    updateFolder, mainFolder);
                if (System.IO.File.Exists(newFile))
                {
                    System.IO.File.Replace(file, newFile, backupFolder);
                }
                else
                {
                    System.IO.File.Move(file, newFile);
                }
            }
        }
