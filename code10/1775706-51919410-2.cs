    //note, you could encapsulate functionality in an interface, e.g.: IService
    public class SomeService 
    {
         public event EventHandler<YourEventData> OnSomethingHappening;
         public SomeService(some parameters)
         {
             //some init procedure
         }
         public void Stop()
         {
            //your stop logic
         }
         public void Start()
         {
            //your start logic
         }
     
         private void Runner() //this might run on a seperate thread
         {
             while(running)
             { 
                 if (somecondition)
                 {
                      OnSomethingHappening?.Invoke(this, new YourEventData());
                 }
             }
         }
         public string SomeFooPropertyToGetOrSetData {get;set;}
    }
