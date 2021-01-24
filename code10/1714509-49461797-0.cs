    public static void GetData(Channel info, string pagetoken =null)
    {
       // get the data from api
       var result = GetResultFromServer(info,pagetoken);        
       while(result != null)
       {
          //handle content of one page
          //
          // do something with one page.. add it to a result list or whatever 
          // you have to do
          // 
          if(result.nextPageToken != null)
          {
             var result = GetResultFromServer(info,result.nextPageToken )
           }
           else{result = null}
       }
       // enter into database
      return;
    }
