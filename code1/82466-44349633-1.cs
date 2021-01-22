    public class ObservableByTrackingTestClass : ObservableByTracking<ObservableByTrackingTestClass>
      {
        public ObservableByTrackingTestClass()
        {
          StringList = new List<string>();
          StringIList = new List<string>();
          NestedCollection = new List<ObservableByTrackingTestClass>();
        }
    
        public IEnumerable<string> StringList
        {
          get { return GetValue(() => StringList); }
          set { SetValue(() => StringIList, value); }
        }
    
        public IList<string> StringIList
        {
          get { return GetValue(() => StringIList); }
          set { SetValue(() => StringIList, value); }
        }
    
        public int IntProperty
        {
          get { return GetValue(() => IntProperty); }
          set { SetValue(() => IntProperty, value); }
        }
    
        public ObservableByTrackingTestClass NestedChild
        {
          get { return GetValue(() => NestedChild); }
          set { SetValue(() => NestedChild, value); }
        }
    
        public IList<ObservableByTrackingTestClass> NestedCollection
        {
          get { return GetValue(() => NestedCollection); }
          set { SetValue(() => NestedCollection, value); }
        }
    
        public string StringProperty
        {
          get { return GetValue(() => StringProperty); }
          set { SetValue(() => StringProperty, value); }
        }
      }
