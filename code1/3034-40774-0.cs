    public class ResizeFolderBackgroundWorker : BackgroundWorker
    {
        public ResizeFolderBackgroundWorker(string sourceFolder, int resizeTo)
        {
            this.sourceFolder = sourceFolder;
            this.destinationFolder = destinationFolder;
            this.resizeTo = resizeTo;
            this.WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(ResizeFolderBackgroundWorker_DoWork);
        }
        void ResizeFolderBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(sourceFolder);
            FileInfo[] files = dirInfo.GetFiles("*.jpg");
            
            foreach (FileInfo fileInfo in files)
            {
                /* iterate over each file and resizing it */
            }
        }
    }
