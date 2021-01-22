    var outputFile = Path.GetTempFileName();
    info = new System.Diagnostics.ProcessStartInfo("TheProgram.exe", String.Join(" ", args) + " > " + outputFile + " 2>&1");
    info.CreateNoWindow = true;
    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    info.UseShellExecute = false;
    System.Diagnostics.Process p = System.Diagnostics.Process.Start(info);
    p.WaitForExit();
    Console.WriteLine(File.ReadAllText(outputFile)); //need the StandardOutput contents
