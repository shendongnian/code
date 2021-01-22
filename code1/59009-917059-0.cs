    try
    {
       path = path_to_your_executable;
       ProcessStartInfo myProcess = new ProcessStartInfo(path);
       myProcess.Domain = domain;
       myProcess.UserName = username;
       myProcess.Password = password;
       myProcess.UseShellExecute = false;
       Process.Start(myProcess);
    }
    catch (Exception myException)
    {
       // error handling
    }
