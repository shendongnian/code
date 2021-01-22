    interface Iface
    {
      object Prop1 { get; }
      object Prop2 { get; }
    }
    class Class1 : Iface
    {
      public string Prop1 { get; }
      public int Prop2 { get; }
      object Iface.Prop1
      {
          get { return Prop1; }
      }
      object Iface.Prop2
      {
          get { return Prop2; }
      }      
    }
    class Class2 : Iface
    {
      public int Prop1 { get; }
      public bool? Prop2 { get; }
      object Iface.Prop1
      {
          get { return Prop1; }
      }
      object Iface.Prop2
      {
          get { return Prop2; }
      }  
    }
