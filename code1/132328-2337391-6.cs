    public class ComponentExporterBase: IDisposable {
      private List<IDisposable> _list;
      public ComponentExporterBase()  {
        _list = new List<IDisposable>();
      }
      protect void Add(IDisposable obj) {
        _list.Add(obj);
      }
      protected virtual void Dispose(bool disposing) {
        if (disposing) {
          foreach(var obj in _list) {
            obj.Dispose();
          }
          _list.Clear();
        }
      }  
 
      public void Dispose()  {
        Dispose(true);
      }
    }
