    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
    process.Start();
