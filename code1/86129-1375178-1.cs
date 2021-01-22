    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;
    using System.ComponentModel;
    public sealed class CDataWrapper : IXmlSerializable
    {
      // implicit to/from string
      public static implicit operator string(CDataWrapper value)
      {
        return value == null ? null : value.Value;
      }
      public static implicit operator CDataWrapper(string value)
      {
        return value == null ? null : new CDataWrapper { Value = value };
      }
      public System.Xml.Schema.XmlSchema GetSchema()
      {
        return null;
      }
      // "" => <Node/>
      // "Foo" => <Node><![CDATA[Foo]]></Node>
      public void WriteXml(XmlWriter writer)
      {
        if (!string.IsNullOrEmpty(Value))
        {
          writer.WriteCData(Value);
        }
      }
      // <Node/> => ""
      // <Node></Node> => ""
      // <Node>Foo</Node> => "Foo"
      // <Node><![CDATA[Foo]]></Node> => "Foo"
      public void ReadXml(XmlReader reader)
      {
        if (reader.IsEmptyElement)
        {
          Value = "";
        }
        else
        {
          reader.Read();
          switch (reader.NodeType)
          {
            case XmlNodeType.EndElement:
              Value = ""; // empty after all...
              break;
            case XmlNodeType.Text:
            case XmlNodeType.CDATA:
              Value = reader.ReadContentAsString();
              break;
            default:
              throw new InvalidOperationException("Expected text/cdata");
          }
        }
      }
	  // underlying value
      public string Value { get; set; }
      public override string ToString()
      {
        return Value;
      }
    }
    // example usage
    [DataContract(Namespace="http://myobjects/")]
    public sealed class MyType
    {
      public string SomeValue { get; set; }
      [DataMember(Name = "SomeValue", EmitDefaultValue = false)]
      private CDataWrapper SomeValueCData
      {
        get { return SomeValue; }
        set { SomeValue = value; }
      }
      public string EmptyTest { get; set; }
      [DataMember(Name = "EmptyTest", EmitDefaultValue = false)]
      private CDataWrapper EmptyTestCData
      {
        get { return EmptyTest; }
        set { EmptyTest = value; }
      }
      public string NullTest { get; set; }
      [DataMember(Name = "NullTest", EmitDefaultValue = false)]
      private CDataWrapper NullTestCData
      {
        get { return NullTest ; }
        set { NullTest = value; }
      }
    }
    // test rig
    static class Program
    {
      static void Main()
      {
        DataContractSerializer dcs = new DataContractSerializer(typeof(MyType));
        StringWriter writer = new StringWriter();
        using (XmlWriter xw = XmlWriter.Create(writer))
        {
          MyType foo = new MyType
          {
            SomeValue = @"&<t\d",
            NullTest = null,
            EmptyTest = ""
          };
          ShowObject("Original", foo);
          dcs.WriteObject(xw, foo);
          xw.Close();
        }
        string xml = writer.ToString();
        ShowObject("Xml", xml);
        StringReader reader = new StringReader(xml);
        using (XmlReader xr = XmlReader.Create(reader))
        {
          MyType bar = (MyType) dcs.ReadObject(xr);
          ShowObject("Recreated", bar);
        }
      }
      static void ShowObject(string caption, object obj)
      {
        Console.WriteLine();
        Console.WriteLine("** {0} **", caption );
        Console.WriteLine();
        if (obj == null)
        {
          Console.WriteLine("(null)");
        }
        else if (obj is string)
        {
          Console.WriteLine((string)obj);
        }
        else
        {
          foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(obj))
          {
            Console.WriteLine("{0}:\t{1}", prop.Name, prop.GetValue(obj) ?? "(null)");
          }
        }
      }
    }
