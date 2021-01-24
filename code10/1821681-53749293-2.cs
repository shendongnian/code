    public async void LoadDataFromApi()
    {
        IsBusy=true;  //Show the Indicator
        var response= await YourService.Method();  //this is where you calling your api
        //do other stuffs if you need to do;
        IsBusy=false;   //Hide the Indicator
    }
