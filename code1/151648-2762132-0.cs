    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    namespace XmlIncludeExample
    {
        [XmlInclude(typeof(DerivedClass))]
        public class BaseClass
        {
            public string ClassName = "Base Class";
        }
        public class DerivedClass : BaseClass
        {
            public string InheritedName = "Derived Class";
        }
        class Program
        {
            static void Main(string[] args)
            {
                string fileName = "Test.xml";
                string fileFullPath = Path.Combine(Path.GetTempPath(), fileName);
                try
                {
                    DerivedClass dc = new DerivedClass();
                    using (FileStream fs = new FileStream(fileFullPath, FileMode.CreateNew))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(BaseClass));
                        xs.Serialize(fs, dc);
                    }
                    using (FileStream fs = new FileStream(fileFullPath, FileMode.Open))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(BaseClass));
                        DerivedClass dc2 = xs.Deserialize(fs) as DerivedClass;
                    }
                }
                finally
                {
                    if (File.Exists(fileFullPath))
                    {
                        File.Delete(fileFullPath);
                    }
                }
            }
        }
    }
