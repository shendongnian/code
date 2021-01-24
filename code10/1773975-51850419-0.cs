    bool _shouldStop { get; set; }
    
    public static Main(string[] args)
    {
    Thread thread = new Thread(print);
    thread.Start();
    
    //your code here while the worker writes "Test" to console
   
    if(condition)
       _shouldStop=true;
     }    
    //...
 
    public void print()
    {
       while (!_shouldStop)
       {
           Console.WriteLine("test");
       }
       Console.WriteLine("worker terminated");
    }
