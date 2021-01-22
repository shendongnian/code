    using System.Diagnostics;
    
        namespace Foo
        
        {
        
            class Bar
        
            {
        
                static void Main(string[] args)
        
                {
        
                    Process p = Process.GetCurrentProcess();
        
                    Process [] processSearch = Process.GetProcessesByName(p.ProcessName);
        
                    if (processSearch.Length > 1)
        
                    {
        
                        return;
        
                    }
        
                }
             }
        }
