    public bool CheckThatService(string serviceUrl)
    {
        ....
    }
    
    public static async Task Main()
    {
        var url="...";
        //...
        while(true)
        {
            var ok=Task.Run(()=>CheckThatService(url));
            if(!ok)
            {
                //That was an error, do something with it
            }
            await Task.Delay(1000);
        }
    }
