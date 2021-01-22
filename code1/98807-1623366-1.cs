    public void ExecuteCommandSync(String command, String args) {
 
     try {   
       System.Diagnostics.ProcessStartInfo procStartInfo =
        new System.Diagnostics.ProcessStartInfo("\""+command+"\"",args);
    
       Process.StandardOutput StreamReader.
       procStartInfo.RedirectStandardOutput = true;
       procStartInfo.UseShellExecute = false;
       
       procStartInfo.CreateNoWindow = true;
       
       System.Diagnostics.Process proc = new System.Diagnostics.Process();
       proc.StartInfo = procStartInfo;
       proc.Start();
       
       string result = proc.StandardOutput.ReadToEnd();
       
       Debug.WriteLine(result);
      } catch (Exception objException) {   
       // Log the exception
      }
