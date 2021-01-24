    try {
    int delay = 400;
        if (exists)
        {
            File.Delete(@"C:\Users\Admin\source\Bargstedt.csv");
            Thread.Sleep(delay); // to prevent delete and copy happening at the 
            // same time.
        }
        System.IO.File.Copy(s, destFile, true);                          
    }catch (IOException ex) {}
