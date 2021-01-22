    string proc = Process.GetCurrentProcess().ProcessName;
    if (Process.GetProcessesByName(proc).Length > 1) {
        Thread.Sleep(500);      //500 milliseconds; you might need to wait longer
        if (Process.GetProcessesByName(proc).Length > 1) {
            MessageBox.Show("Lockerz Desktop is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }    //no else
