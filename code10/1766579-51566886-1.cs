        bool bFileFound = false;
        int iLoopCount = 0; //remove loop count if you need to keep looking forever.
        string wimpath = "sources\\install.wim";
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        do
        {
            foreach (DriveInfo d in allDrives)
            {
                if (File.Exists(d + wimpath))
                {
                    wimDsk = d + wimpath;
                    MessageBox.Show("Install.WIM found at " + wimDsk);
                    bFileFound = true;
                    break;
                }
            }
            iLoopCount++;
            if (!bFileFound)
            {
                System.Threading.Thread.Sleep(100);
            }
        } while (!bFileFound && iLoopCount < 100000);
