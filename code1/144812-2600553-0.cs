    //somewhere on your code or put on a singleton
    static  System.Collections.Generic.HashSet<String> filesAlreadyProcessed= new  System.Collections.Generic.HashSet<String>();
    
    
    //thread main method code
    bool filealreadyprocessed = false
    lock(filesAlreadyProcessed){
      if(set.Contains(filename)){
        filealreadyprocessed= true;
      }
      else{
         set.Add(filename)
      }
    }
    if(!filealreadyprocessed){
    //ProcessFile
    }
