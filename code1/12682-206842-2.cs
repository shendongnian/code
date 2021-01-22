    // This is just an example, obviously you'll want to pass args to this.
    Process p1 = new Process();
    p1.StartInfo.FileName = "ApplyTransform.exe";
    p1.StartInfo.UseShellExecute = false;
    p1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    p1.Start();
    p1.WaitForExit();
    if (p1.ExitCode == 1)    
       Console.WriteLine("StackOverflow was thrown");
 
