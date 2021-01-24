    void Start()
    {
        //This Start function is the main Thread (Unity's Thread)
    
        //Get path in the Main Thread
        string dbPath = Application.persistentDataPath;
    
        var thread = new System.Threading.Thread(() =>
        {
            //This is another Thread created by you
    
            //Use the path result here
    
    
            //do sqlite operations
        });
        thread.Start();
    }
