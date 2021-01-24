    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                name Name = new name()
                {
                    firstname = "John",
                    lastname = "Smith"
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME,settings);
                XmlSerializer serializer = new XmlSerializer(typeof(name));
                serializer.Serialize(writer,Name);
                writer.Close();
                XmlReader reader = XmlReader.Create(FILENAME);
                name readName = (name)serializer.Deserialize(reader);
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://webaddress.com/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://webaddress.com/", IsNullable = false)]
        public partial class name
        {
            private string firstnameField;
            private string lastnameField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string firstname
            {
                get
                {
                    return this.firstnameField;
                }
                set
                {
                    this.firstnameField = value;
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string lastname
            {
                get
                {
                    return this.lastnameField;
                }
                set
                {
                    this.lastnameField = value;
                }
            }
        }
    }
