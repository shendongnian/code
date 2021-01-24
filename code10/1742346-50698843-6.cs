    //Make class static variable so that the callback function is sent to one instance of this class.
     public static MyPlugin testInstance;
     public static MyPlugin instance()
     {
         if(testInstance == null)
         {
             testInstance = new MyPlugin();
         }
         return testInstance;
     }
    string result = "";
    public string UnitySendMessageExtension(string gameObject, string functionName, string funcParam)
    {
        UnityPlayer.UnitySendMessage(gameObject, functionName, funcParam);
        string tempResult = result;
        return tempResult;
    }
    //Receives result from C# and saves it to result  variable
    void receiveResult(string value)
    {
        result = "";//Clear old data
        result = value; //Get new one
    }}
