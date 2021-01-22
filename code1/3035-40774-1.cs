        //handle a button click to start lengthy operation
        private void resizeImageButtonClick(object sender, EventArgs e)
        {
            string sourceFolder = getSourceFolderSomehow();
            resizer = new ResizeFolderBackgroundWorker(sourceFolder,290);
            resizer.ProgressChanged += new progressChangedEventHandler(genericProgressChanged);
            resizer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(genericRunWorkerCompleted);
            
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            resizer.RunWorkerAsync();
        }
        void genericRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            //signal to user that operation has completed
        }
        void genericProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //I just update a progress bar
        }
