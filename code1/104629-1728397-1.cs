    public class ClassWithNonSerializedProperty {
      [NonSerialized]
      private object _data;  // Backing field of Property Data that is not serialized
      public object Data{
        get { return _data; }
        set { _data = value; }
      }
    }
