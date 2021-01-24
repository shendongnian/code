    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication63
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "managedObject")
                    {
                        reader.ReadToFollowing("managedObject");
                    }
                    if (!reader.EOF)
                    {
                        XElement managedObject = (XElement)XElement.ReadFrom(reader);
                        ManagedObject newObject = new ManagedObject();
                        ManagedObject.objects.Add(newObject);
                        newObject.mClass = (string)managedObject.Attribute("class");
                        newObject.distName = (string)managedObject.Attribute("distName");
                        newObject.hierachy = newObject.distName.Split(new char[] { '/' });
                        newObject.objectdict = managedObject.Elements()
                            .GroupBy(x => (string)x.Attribute("name"), y => (string)y)
                            .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    }
                }
                ManagedObjectNode.CreateTree();
            }
            public class ManagedObject
            {
                public static List<ManagedObject> objects = new List<ManagedObject>();
                public Dictionary<string, string> objectdict { get; set; }
                public string distName { get; set; }
                public string mClass { get; set; }
                public string[] hierachy { get; set; }
            }
            public class ManagedObjectNode
            {
                public static ManagedObjectNode root = new ManagedObjectNode();
                public Dictionary<string, ManagedObjectNode> children { get; set; }
                public List<ManagedObject> leaves { get; set; }
                public string nodeName { get; set; }
                public static void CreateTree()
                {
                    root.nodeName = "root";
                    GetTreeRecursive(root, ManagedObject.objects, 0);
                }
                public static void GetTreeRecursive(ManagedObjectNode parent, List<ManagedObject> mObjects, int level)
                {
                    var groups = mObjects.GroupBy(x => x.hierachy[level]).ToList();
                    foreach (var group in groups)
                    {
                        ManagedObjectNode newNode = new ManagedObjectNode();
                        newNode.nodeName = group.Key;
                        if (parent.children == null) parent.children = new Dictionary<string, ManagedObjectNode>();
                        parent.children.Add(group.Key, newNode);
                        newNode.leaves = mObjects.Where(x => x.hierachy.Count() - 1 == level).ToList();
                        List<ManagedObject> hasChildren = mObjects.Where(x => x.hierachy.Count() - 1 > level).ToList();
                        if (hasChildren.Count() > 0)
                        {
                            GetTreeRecursive(newNode, hasChildren, level + 1);
                        }
                    }
                }
            }
        }
    }
