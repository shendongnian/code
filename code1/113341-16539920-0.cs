    public partial class ReadAndChange : System.Web.UI.Page
    {
        ArrayList FolderList = new ArrayList();
        ArrayList FolderListSearch = new ArrayList();
        ArrayList FileList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            AllFolderList("D:\\BinodBackup\\Nilesh\\14.5.2013\\Source");
            foreach (string Path in FolderList)
            {
                AllFileList(Path);
            }
            foreach (string Path in FileList)
            {
                ReplaceFile(Path, Path.Replace("Source", "EditedCode"));
            }
    
            //string SourcePath = "D:\\BinodBackup\\Nilesh\\14.5.2013\\Onesource\\Onesource\\UserManagement\\UserControls\\AddUserDetails.ascx.cs";
            //string ReplacePath = "D:\\AddUserDetails.ascx.cs";
            //ReplaceFile(SourcePath, ReplacePath);
        }
    
        private static void ReplaceFile(string SourcePath, string ReplacePath)
        {
            int counter = 1;
            string line;
    
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(SourcePath);
            while ((line = file.ReadLine()) != null)
            {
                if (!(line.Contains("//")))
                {
                    if (line.Contains(".LogException("))
                    {
                        //Console.WriteLine(counter.ToString() + ": " + line);
                        string[] arr = line.Split(',');
                        string stringToReplace = arr[0].Replace("LogException", "Publish") + " , " + arr[2].Trim() + " , " + arr[3].Replace(");", "").Trim() + " , " + arr[1].Trim() + ");";
                        //File.WriteAllText(currentPath, Regex.Replace(File.ReadAllText(currentPath), line, line + " Added"));
                        File.WriteAllText(ReplacePath, File.ReadAllText(ReplacePath).Replace(line, stringToReplace));
                        //ReplaceInFile(currentPath, line, stringToReplace);
                    }
                }
    
                counter++;
            }
    
            file.Close();
        }
        private void AllFileList(string FolderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderPath);
            DirectoryInfo[] subdir = dir.GetDirectories();
            if (subdir.Length > 0)
            {
    
                foreach (DirectoryInfo dr in subdir)
                {
                    FileInfo[] files1 = dr.GetFiles();
                    foreach (FileInfo file in files1)
                    {
                        if(file.Name.EndsWith(".cs"))
                        CheckAndAdd((file.DirectoryName + "\\" + file.Name), FileList);
                    }
    
                }
            }
        }
    
        private void AllFolderList(string FolderPath)
        {
            string CurFolderPatgh = FolderPath;
            Again:
            AddToArrayList(CurFolderPatgh);
            DirectoryInfo dir = new DirectoryInfo(CurFolderPatgh);
            DirectoryInfo[] subdir = dir.GetDirectories();
    
            if (subdir.Length > 0)
            {
                foreach (DirectoryInfo dr in subdir)
                {
                    AddToArrayList(((System.IO.FileSystemInfo)(dir)).FullName + "\\" + dr.Name);
                }
            }
            if (FolderListSearch.Count > 0)
            {
                foreach (string dr in FolderListSearch)
                {
                    CurFolderPatgh = dr;
                    FolderListSearch.Remove(dr);
                    goto Again;
                }
            }
        }
    
        private void AddToArrayList(string FolderPath)
        {
            if (!(FolderList.Contains(FolderPath)))
            {
                CheckAndAdd(FolderPath, FolderList);
                CheckAndAdd(FolderPath, FolderListSearch);
            }
        }
    
        private void CheckAndAdd(string FolderPath,ArrayList ar)
        {
            if (!(ar.Contains(FolderPath)))
            {
                ar.Add(FolderPath);
            }
        }
    
        public static void ReplaceInFile(
                          string filePath, string searchText, string replaceText)
        {
    
            var content = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
                reader.Close();
            }
    
            content = content.Replace(searchText, replaceText);
    
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
                writer.Close();
            }
        }
    }
