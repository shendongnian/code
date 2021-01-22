    namespace MyProgram.MySchemas {
        using System.Xml.Serialization;
       
        public partial class MySchema {
            [XmlAttribute("schemaLocation", Namespace = System.Xml.Schema.XmlSchema.InstanceNamespace)]
            public string xsiSchemaLocation = @"http://someurl/myprogram http://someurl/myprogram/MySchema.xsd";
        }
    }
