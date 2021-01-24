    void Start()
    {
        //This Start function is the main Thread (Unity's Thread)
    
        var thread = new System.Threading.Thread(() =>
        {
            //This is another Thread created by you
    
            //DO NOT DO THIS(Don't use Unity API in another Thread)
            string dbPath = Application.persistentDataPath;
    
            //do sqlite operations
        });
        thread.Start();
    }
