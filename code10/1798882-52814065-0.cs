    var t = new Task(); 
    t.ContinueWith(o =>{
        if(o.IsFaulted){
            Console.WriteLine(o.Exception?.InnerException);
        return;
        }
        Console.WriteLine(o.Result);
      });
