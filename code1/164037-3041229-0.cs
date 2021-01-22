    // WPF
    System.Threading.Thread t = new System.Threading.Thread(() =>
    {
        // copy file logic 
        // wpf user interface update
        Dispatcher.BeginInvoke(() =>
        {
            // progressBar Update
        });                
    });
    // WinForms
    System.Threading.Thread t = new System.Threading.Thread(() =>
    {
        // copy file logic 
        // WinForms UI Update
        Form1.BeginInvoke(() =>
        {
            // progressBar Update
        });                
    });
