    System.Diagnostics.Process proc = new System.Diagnostics.Process(); 
    
    proc.EnableRaisingEvents=false;
    proc.StartInfo.FileName="iexplore";
    proc.StartInfo.Arguments=http://www.microsoft.com;
    
    proc.Start();
    
    proc.WaitForExit();
    
    MessageBox.Show("You have just visited www.microsoft.com");
