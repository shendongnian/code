    public class MyMainController : IController {
       private IDataReader _dataReader;
       // dataReader is injected through CTOR
       public MyMainControler(IDataReader dataReader) {
         _dataReader = dataReader; 
         ...
       }
       ...
       public void Dispose() {
         // dispose only resources created in this class
         // _dataReader is not disposed here or within the class!
         ...}
    }
