    var tasks = new List<Task>(); 
    tasks.add(t.ContinueWith(o =>
    {
		if(o.IsFaulted){
			Console.WriteLine(o.Exception?.InnerException);
			return;
			}
		
			Console.WriteLine(o.Result);
      }));
   
     tasks.WhenAll().ContinueWith(o=>{
	
	Console.WriteLine("All Done!")
    });
