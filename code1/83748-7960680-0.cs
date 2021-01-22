    [Serializable]
    public class MyClass : ISerializable
    {
    
       bool TorF=true;
       string str="Save me";
       public MyClass() {//need a constructor for your access}
      #region Serialisation
      //read in data
      public MyClass(SerializationInfo info, StreamingContext context)
      {
       TorF=(bool)info.GetValue("WS_TorF",typeof(bool));
       str=(string)info.GetValue("str",typeof(string)); 
      }
    
      //write out data
      public void GetObjectData(SerializationInfo info, StreamingContext context)
      {
        info.AddValue("TorF", TorF);
        info.AddValue("str", str);
      }
    }
