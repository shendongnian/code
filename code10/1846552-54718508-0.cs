        static object padlock = new object();
        static void Main(string[] args)
        {
            OracleConnection ora = new OracleConnection(Properties.Settings.Default.ora);
            ora.Open();
            new OracleCommand("DELETE FROM SCRPT_APP.S_DRIVE_FOLDERS", ora).ExecuteNonQuery();
            ora.Close();
            string folderName = Properties.Settings.Default.rootFolder;
            Task processRoot = new Task((value) =>
            {
                getFolderData(value);
            }, folderName);
            //wait is like join;  it waits for this asynchronous task to finish.
            processRoot.Start();
            processRoot.Wait();
        }
        // recursive routine to walk directory structure and create annotated treeview
        private static void getFolderData(object objFolderName)
        {
            string folderName = (string)objFolderName;
            Console.WriteLine(folderName);
            long folderSize = 0;
            string[] directories = new string[] { };
            string[] files = new string[] { };
            try
            {
                directories = Directory.GetDirectories(folderName);
            }
            catch { };
            try
            {
                files = Directory.GetFiles(folderName);
            }
            catch { }
            for (int f = 0; f < files.Length; f++)
            {
                try
                {
                    folderSize += new FileInfo(files[f]).Length;
                }
                catch { } //cannot access file so skip;
            }
            FolderData folderData = new FolderData(folderName, directories.Length, files.Length, folderSize);
            List<String> directoryList = directories.ToList<String>();
            directoryList.Sort();
            //create a task for each subdirectory
            List<Task> dirTasks = new List<Task>();
            for (int d = 0; d < directoryList.Count; d++)
            {
                
               
                dirTasks.Add(new Task((value) =>
               {
                   getFolderData(value);
               }, directoryList[d]));
               
            }
            //start all tasks
            foreach (Task task in dirTasks)
            {
                task.Start();
            }
            //wait fo them to finish
            Task.WaitAll(dirTasks.ToArray());
            addToDB(folderData);
        }
        private static void addToDB(FolderData folderData)
        {
            lock (padlock)
            {
                OracleConnection ora = new OracleConnection(Properties.Settings.Default.ora);
                ora.Open();
                OracleCommand addFolderData = new OracleCommand(
                    "INSERT INTO FOLDERS " +
                    "(PATH, FOLDERS, FILES, SPACE_USED) " +
                    "VALUES " +
                    "(:PATH, :FOLDERS, :FILES, :SPACE_USED) ",
                ora);
                addFolderData.BindByName = true;
                addFolderData.Parameters.Add(":PATH", OracleDbType.Varchar2);
                addFolderData.Parameters.Add(":FOLDERS", OracleDbType.Int32);
                addFolderData.Parameters.Add(":FILES", OracleDbType.Int32);
                addFolderData.Parameters.Add(":SPACE_USED", OracleDbType.Int64);
                addFolderData.Prepare();
                addFolderData.Parameters[":PATH"].Value = folderData.FolderName;
                addFolderData.Parameters[":FOLDERS"].Value = folderData.FolderCount;
                addFolderData.Parameters[":FILES"].Value = folderData.FileCount;
                addFolderData.Parameters[":SPACE_USED"].Value = folderData.Size;
                addFolderData.ExecuteNonQuery();
                ora.Close();
            }
        }
    }
}
