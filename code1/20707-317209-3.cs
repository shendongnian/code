    using System.Management; 
    using System.IO;   
    static class Module1 
    { 
    static internal ArrayList myProcessArray = new ArrayList(); 
    private static Process myProcess; 
    
    public static void Main() 
    { 
        
        string strFile = "c:\\windows\\system32\\msi.dll"; 
        ArrayList a = getFileProcesses(strFile); 
        foreach (Process p in a) { 
            Debug.Print(p.ProcessName); 
        } 
    } 
    
    
    private static ArrayList getFileProcesses(string strFile) 
    { 
        myProcessArray.Clear(); 
        Process[] processes = Process.GetProcesses; 
        int i = 0; 
        for (i = 0; i <= processes.GetUpperBound(0) - 1; i++) { 
            myProcess = processes(i); 
            if (!myProcess.HasExited) { 
                try { 
                    ProcessModuleCollection modules = myProcess.Modules; 
                    int j = 0; 
                    for (j = 0; j <= modules.Count - 1; j++) { 
                        if ((modules.Item(j).FileName.ToLower.CompareTo(strFile.ToLower) == 0)) { 
                            myProcessArray.Add(myProcess); 
                            break; // TODO: might not be correct. Was : Exit For 
                        } 
                    } 
                } 
                catch (Exception exception) { 
                } 
                //MsgBox(("Error : " & exception.Message)) 
            } 
        } 
        return myProcessArray; 
    } 
    } 
