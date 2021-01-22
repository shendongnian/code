    //Set the AppId
    string AppId = ""+DateTime.Now.Ticks(); //A random title
    
    //Create an identity for the app
    
    this.oWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
    this.oWordApp.Application.Caption = AppId;
    this.oWordApp.Application.Visible = true;
    
    ///Get the pid by for word application
    this.WordPid = StaticMethods.GetProcessIdByWindowTitle(AppId);
    
    while ( StaticMethods.GetProcessIdByWindowTitle(AppId) == Int32.MaxValue) //Loop till u get
    {
        Thread.Sleep(5);
    }
    
    this.WordPid = StaticMethods.GetProcessIdByWindowTitle(AppId);
                 
    
    ///You canh hide the application afterward            
    this.oWordApp.Application.Visible = false;
    
    string this.oWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
    this.oWordApp.Application.Caption = AppId;
    this.oWordApp.Application.Visible = true;
    ///Get the pid by 
    this.WordPid = StaticMethods.GetProcessIdByWindowTitle(AppId);
    while ( StaticMethods.GetProcessIdByWindowTitle(AppId) == Int32.MaxValue)
    {
        Thread.Sleep(5);
    }
    
    this.WordPid = StaticMethods.GetProcessIdByWindowTitle(AppId);
     
    this.oWordApp.Application.Visible = false; //You Can hide the application now
    
    /// <summary>
    /// Returns the name of that process given by that title
    /// </summary>
    /// <param name="AppId">Int32MaxValue returned if it cant be found.</param>
    /// <returns></returns>
    public static int GetProcessIdByWindowTitle(string AppId)
    {
       Process[] P_CESSES = Process.GetProcesses();
       for (int p_count = 0; p_count < P_CESSES.Length; p_count++)
       {
            if (P_CESSES[p_count].MainWindowTitle.Equals(AppId))
            {
                        return P_CESSES[p_count].Id;
            }
       }
    
        return Int32.MaxValue;
    }
      
