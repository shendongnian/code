    public void Main()
        {
            DirectoryInfo di = new DirectoryInfo(Dts.Variables["IN_Folder"].Value.ToString());
            string destinationFolder = Dts.Variables["User::IN_Folder_Processing"].Value.ToString();
            FileInfo[] fi = di.GetFiles("*.txt");
            foreach (FileInfo f in fi)
            {
                FileInfo destinationFile = new FileInfo(Path.Combine(destinationFolder, f.Name));
                if (destinationFile.Exists)
                    destinationFile.Delete();
                f.MoveTo(destinationFile.FullName);
            }
            Dts.TaskResult = (int)ScriptResults.Success;
        }
