    using System.Diagnostics;
    
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        ProcessStartInfo myAppProcessInfo = new ProcessStartInfo("myApp.exe");
        myAppProcessInfo.WindowStyle = ProcessWindowStyle.Maximized;
        Process myAppProcess = Process.Start(myAppProcessInfo);
    }
