    Process[] processes = Process.GetProcessesByName("MyApp");
    foreach (Process process in processes)
    {
         string username = process.StartInfo.Environment["USERNAME"];
         // do some stuff
    } 
