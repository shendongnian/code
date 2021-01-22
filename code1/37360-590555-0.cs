    abstract class MyData { 
       protected abstract object GetData();
       protected abstract Type GetDataType(); 
       public object Data {
          get { return GetData(); } 
       }
       public Type DataType {
          get { return GetDataType(); } 
       }
    }
    
    class MyData<T> : MyData { 
       protected override object GetData() { return Data; }
       protected override Type GetDataType() { return typeof(T); }
       public new T Data {
         get { ... }
       }
    }
