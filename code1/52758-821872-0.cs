    [Serializable]
    public class ClassB : IB, ISerializable
    {
      public IA InterfaceA { get; set; }
      public void SetIA(IA value)
      {
         this.InterfaceA = value as ClassA;
      }
      private MyStringData(SerializationInfo si, StreamingContext ctx) {
        Type interfaceAType = System.Type.GetType(si.GetString("InterfaceAType"));
        this.InterfaceA = si.GetValue("InterfaceA", interfaceAType);
      }
      void GetObjectData(SerializationInfo info, StreamingContext ctx) {
        info.AddValue("InterfaceAType", this.InterfaceA.GetType().FullName);
        info.AddValue("InterfaceA", this.InterfaceA);
      }
    }
