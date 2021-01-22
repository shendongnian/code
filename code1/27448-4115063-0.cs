    int DeletedCount = 0;
            int CouldNotDelete = 0;
            KillExplorer();
            foreach (string DatFile in DatFiles)
            {//Do not put break point or step into the code else explorer will start and the file will become locked again
                DirectoryInfo DInfo=new DirectoryInfo(DatFile.Replace("index.dat",""));
                FileAttributes OldDirAttrib = DInfo.Attributes;
                DInfo.Attributes  = FileAttributes.Normal;//Set to normal else can not delete
                FileInfo FInfo = new FileInfo(DatFile);
                FileAttributes OldFileAttrib = FInfo.Attributes;
                SetAttr(FInfo, FileAttributes.Normal);
                TryDelete(FInfo);
                SetAttr(FInfo, OldFileAttrib);//Sets back to Hidden,system,directory,notcontentindexed
                if (File.Exists(DatFile))
                    CouldNotDelete++;
                else
                    DeletedCount++;
                  
            }
            if (DatFiles.Count>0)//Lets get explorer running again
                System.Diagnostics.Process.Start(DatFiles[DatFiles.Count - 1].Replace("index.dat", ""));
            else
                System.Diagnostics.Process.Start("explorer");
            System.Windows.Forms.MessageBox.Show("Deleted " + DeletedCount + " Index.dat files with " + CouldNotDelete + " Errors");
           
            return "Deleted " + DeleteFileCount + " Files ";
        }
        private void KillExplorer()
        {
            foreach (Process P in Process.GetProcesses())
            {//Kill both these process because these are the ones locking the files
                if (P.ProcessName.ToLower() == "explorer")
                    P.Kill();
                if (P.ProcessName.ToLower() == "iexplore")
                    P.Kill();
            }
        }
        private bool TryDelete(FileInfo Info)
        {
            try
            {
                Info.Delete();
                return true;
            }
            catch 
            {return false;}
        }
        private void SetAttr(FileInfo Info,FileAttributes Attr)
        {
            try
            {
                Info.Attributes = Attr;
            }
            catch { }
        }
