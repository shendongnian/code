    using System.Diagnostics;
    // Prepare the process to run
    ProcessStartInfo start = new ProcessStartInfo();
    // Enter in the command line arguments, everything you would enter after the executable name itself
    start.Arguments = arguments; 
    // Enter the executable to run, including the complete path
    start.FileName = ExeName;
    // Do you want to show a console window?
    start.WindowStyle = ProcessWindowStyle.Hidden;
    start.CreateNoWindow = true;
    int exitCode;
    
    // Run the external process & wait for it to finish
    using (Process proc = Process.Start(start))
    {
         proc.WaitForExit();
                       
         // Retrieve the app's exit code
         exitCode = proc.ExitCode;
    }
