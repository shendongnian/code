    public double GetWSHFolderSize(string Fldr)
        {
            //Reference "Windows Script Host Object Model" on the COM tab.
            IWshRuntimeLibrary.FileSystemObject FSO = new     IWshRuntimeLibrary.FileSystemObject();
            double FldrSize = (double)FSO.GetFolder(Fldr).Size;
            Marshal.FinalReleaseComObject(FSO);
            return FldrSize;
        }
    private void button1_Click(object sender, EventArgs e)
            {
                string folderPath = @"C:\Windows";
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            double sizeOfDir = GetWSHFolderSize(folderPath);
            sWatch.Stop();
            MessageBox.Show("Directory size in Bytes : " + sizeOfDir + ", Time: " + sWatch.ElapsedMilliseconds.ToString());
              }
