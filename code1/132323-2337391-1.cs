    internal class MyDIMappingClass : ComponentExporterBase {
      [Import]
      private IDataReader _dataReader { get; set; }
      [Import]
      private IMainController _contoller { get; set; }
      [Export]
      private IDataReader {
        get {
          var instance = new MyDataReader();
          base.Add(instance); // IDataReader is an IDisposable
          return instance;
      }
      [Export]
      private IController {
          get {
             // DIHelper class is my helper class where the 
             // root CompositionContainer is used to get an instance
             // from MEF. Class codes are omitted
             var reader = DIHelper.GetInstanace<IDataReader>();
             var instance = new MyMainController(reader);
             base.Add(instance);
             return instance;
    }
