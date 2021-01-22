    public interface IInterface {}
    public class KnownImplementor01 : IInterface {}
    public class KnownImplementor02 : IInterface {}
    public class KnownImplementor03 : IInterface {}
    public class ToSerialize {
      [XmlIgnore]
      public IInterface InterfaceProperty { get; set; }
      [XmlArray("interface")]
      [XmlArrayItem("ofTypeKnownImplementor01", typeof(KnownImplementor01)]
      [XmlArrayItem("ofTypeKnownImplementor02", typeof(KnownImplementor02)]
      [XmlArrayItem("ofTypeKnownImplementor03", typeof(KnownImplementor03)]
      public object[] InterfacePropertySerialization {
        get { return new[] { InterfaceProperty } }
        set { InterfaceProperty = (IInterface)value.Single(); }
      }
    }
      
