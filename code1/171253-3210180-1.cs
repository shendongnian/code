    public class ViewModel {
      Dictionary<string,string> m_Dynamic;
      
      public string FirstName {return m_Dynamic["FirstName"]; }
      public string LastName {return m_Dynamic["LastName"]; }
    
      public Dictionary<string,string> DynamicObject {get {return m_Dynamic;}}
    }
    
    // In the data mapping layer
    ViewModel vm = new ViewModel();
    Dictionary<string,string> data = new Dictionary<string,string>{{"FirstName", "Igor"}, {"LastName", "Zevaka"}};
    foreach(var kv in data) {
      vm.DynamicObject[kv.Key] = kv.Value;
    }
