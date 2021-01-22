    // WPF
    System.Threading.Thread t = new System.Threading.Thread(() =>
    {
       foreach(String file in filesToCopy)
        {
            // copy file here
            // WPF UI Update
            Dispatcher.BeginInvoke(() =>
            {
                // progressBar Update
            }); 
        }                    
    });
    // WinForms
    System.Threading.Thread t = new System.Threading.Thread(() =>
    {
        foreach(String file in filesToCopy)
        {
            // copy file here
            // WinForms UI Update
            Form1.BeginInvoke(() =>
            {
                // progressBar Update
            }); 
        }               
    });
    // in either case call
    t.Start();
