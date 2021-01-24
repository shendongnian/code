    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Activity activity = new Activity() {
                    Ignorable = "sap sap2010 sads",
                    Class = "Main",
                    NamespacesForImplementation = new NamespacesForImplementation() {
                        Collection = new StringCollection() {
                            TypeArguments = "x:String",
                            String = new List<string>() {
                                "System.Activities", "System.Activities.Statements", "System.Activities.Expressions"
                            }
                        }
                    },
                    ReferencesForImplementation = new ReferencesForImplementation() {
                        Collection = new StringCollection() {
                            TypeArguments = "AssemblyReference",
                            AssemblyReference = new List<string>() {
                                "System.Activities", "Microsoft.VisualBasic", "mscorlib"
                            }
                        }
                    }
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Activity));
                serializer.Serialize(writer, activity);
            }
        }
        [XmlRoot(Namespace = "http://schemas.microsoft.com/netfx/2009/xaml/activities")]
        public class Activity
        {
            [XmlAttribute(AttributeName = "Ignorable", Namespace = "http://schemas.openxmlformats.org/markup-compatibility/2006")]
            public string Ignorable { get; set; }
            [XmlAttribute(AttributeName = "Class", Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
            public string Class { get; set; }
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces Xmlns { get; set; }
            [XmlElement(ElementName = "TextExpression.NamespacesForImplementation", Namespace = "http://schemas.microsoft.com/netfx/2009/xaml/activities")]
            public NamespacesForImplementation NamespacesForImplementation { get; set; }
            [XmlElement(ElementName = "TextExpression.ReferencesForImplementation", Namespace = "http://schemas.microsoft.com/netfx/2009/xaml/activities")]
            public ReferencesForImplementation ReferencesForImplementation { get; set; }
        }
        public class NamespacesForImplementation
        {
            [XmlElement(ElementName = "Collection", Namespace = "clr-namespace:System.Collections.ObjectModel;assembly=mscorlib")]
            public StringCollection Collection { get; set; }
        }
        public class ReferencesForImplementation
        {
            [XmlElement(ElementName = "Collection", Namespace = "clr-namespace:System.Collections.ObjectModel;assembly=mscorlib")]
            public StringCollection Collection { get; set; }
        }
        public class StringCollection
        {
            [XmlAttribute(AttributeName = "TypeArguments", Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
            public string TypeArguments { get; set; }
            [XmlElement(ElementName = "String", Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
            public List<string> String { get; set; }
            [XmlElement(ElementName = "AssemblyReference", Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
            public List<string> AssemblyReference { get; set; }
        }
    }
