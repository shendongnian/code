public class TheStructWorkerClass
{
  private StructData TheStruct;
  public TheStructWorkerClass(StructData yourStruct)
  {
    this.TheStruct = yourStruct;
  }
  public void ExecuteAsync()
  {
    System.Threading.ThreadPool.QueueUserWorkItem(this.TheWorkerMethod);
  }
  private void TheWorkerMethod(object state)
  {
     // your processing logic here
     // you can access your structure as this.TheStruct;
     // only this thread has access to the struct (as long as you don't pass the struct
     // to another worker class)
  }
}
// now hte code that launches the async process does this:
  var worker = new TheStructWorkerClass(yourStruct);
  worker.ExecuteAsync();
