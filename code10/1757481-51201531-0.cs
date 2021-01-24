       private static IntPtr GetModuleBaseAddress(string AppName, string ModuleName) 
        { 
            IntPtr BaseAddress = IntPtr.Zero; 
            Process[] myProcess = null; 
            ProcessModule myProcessModule = null; 
    
            myProcess = Process.GetProcessesByName(AppName); 
    
            if (myProcess.Length > 0) 
            { 
                ProcessModuleCollection myProcessModuleCollection; 
    
                try 
                { 
                    myProcessModuleCollection = myProcess[0].Modules; 
                } 
                catch { return IntPtr.Zero; /*Maybe would be ok show the exception after/instead return*/ } 
    
                for (int i = 0; i < myProcessModuleCollection.Count; i++) 
                { 
                    myProcessModule = myProcessModuleCollection[i]; 
                    if (myProcessModule.ModuleName.Contains(ModuleName)) 
                    { 
                        BaseAddress = myProcessModule.BaseAddress; 
                        break; 
                    } 
                } 
            } 
    
            return BaseAddress; 
        }
