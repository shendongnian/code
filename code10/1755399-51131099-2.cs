    class InformationGetter : IWork
    {
         public int Id {get; set;}                     // the input Id
         public Data FetchedData {get; private set;}   // the result from Remoting.GetData(id);
         public void DoWork()
         {
             this.FetchedData = remoting.GetData(this.Id);
         }
    }
