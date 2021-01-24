    private Task<bool> ISNeededFilesAvailable()
    { 
        return Task.Run(()=>{   
           try{
           IsBusy = true; 
           if(!File.Exist("MyCustomeControls.dll"))
             return false
           if(!File.Exist("PARSGREEN.dll"))
             return false
      
           return true;
           }
           finally
           {
              IsBusy = false;
           }
        });
    }
    
    private async void StartupWindow_Loaded(object sender, RoutedEventArgs e)
       {
        if (! (await ISNeededFilesAvailable()))
         Application.close();
        else
         this.close();
       }
