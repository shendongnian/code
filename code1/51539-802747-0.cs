    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    [DataContract]
    class MyObject {
        public MyObject(Guid id) { this.id = id; }
        [DataMember(Name="Id")]
        private Guid id;
        public Guid Id { get {return id;}}
    }
    static class Program {
        static void Main() {
            var ser = new DataContractSerializer(typeof(MyObject));
            var obj = new MyObject(Guid.NewGuid());
            using(XmlWriter xw = XmlWriter.Create(Console.Out)) {
                ser.WriteObject(xw, obj);
            }
        }
    }
