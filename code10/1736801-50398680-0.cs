    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication45
    {
        class Program
        {
            const string READFILENAME = @"c:\temp\test.xml";
            const string FOLDER = @"c:\temp";
            static void Main(string[] args)
            {
                //new Write(FOLDER, READFILENAME);
                new SiXmlPlugin(READFILENAME);
            }
        }
        //[XmlRoot("Plugin")]
        public class SiXmlPlugin
        {
            public static SiXmlPlugin root = null;
            //[XmlAttribute("Name")]
            public string Name { get; set; }
            //[XmlAttribute("Version")]
            public long Version { get; set; }
            //[XmlAttribute("VersionString")]
            public String VersionString { get; set; }
            //[XmlElement("Files")]
            public List<SiFile> Files = new List<SiFile>();
            //[XmlElement("Folders")]
            public List<SiFolder> Folders = new List<SiFolder>();
            public SiXmlPlugin() { }
            public SiXmlPlugin(string filename)
            {
                XmlReader reader = XmlReader.Create(filename);
                reader.ReadToFollowing("Plugin");
                reader.ReadStartElement();
                root = new SiXmlPlugin();
                int depth = reader.Depth;
                ReadFolderRecursive(root.Folders, reader, depth);
            }
            public static void ReadFolderRecursive(List<SiFolder> folders, XmlReader reader, int depth)
            {
                SiFolder newFolder = null;
                while (!reader.EOF)
                {
                    XmlNodeType nodeType = reader.NodeType;
                    switch (nodeType)
                    {
                        case XmlNodeType.Whitespace:
                            reader.Read();
                            break;
                        case XmlNodeType.Element:
                            switch (reader.Name)
                            {
                                case "Files":
                                    reader.ReadStartElement();
                                    ReadFolderRecursive(folders, reader, reader.Depth); 
                                    break;
                                case "File":
                                    SiFile newFile = new SiFile();
                                    folders.Last().Files.Add(newFile);
                                    newFile.Filename = reader.GetAttribute("Name");
                                    reader.ReadStartElement();
                                    break;
                                case "Folders":
                                    int newDepth = reader.Depth;
                                    if (newDepth < depth) return;
     
                                    if (newDepth == depth)
                                    {
                                        newFolder = new SiFolder();
                                        newFolder.Name = reader.GetAttribute("Name");
                                        folders.Add(newFolder);
                                        reader.ReadStartElement();
                                    }
                                    else
                                    {
                                       if (newFolder.Folders == null)
                                        {
                                            newFolder.Folders = new List<SiFolder>();
                                       }
                                       ReadFolderRecursive(newFolder.Folders, reader, newDepth);
                                    }
                                    break;
                                default:
                                    reader.ReadStartElement();
                                    break;
                            }
                            break;
                        case XmlNodeType.Attribute:
                            break;
                        default:
                            reader.Read();
                            break;
                    }
                }
            }
        //[XmlRoot("Folder")]
        public class SiFolder
        {
            //[XmlAttribute("Name")]
            public string Name { get; set; }
            //[XmlElement("Files")]
            public List<SiFile> Files = new List<SiFile>();
            //[XmlElement("Folders")]
            public List<SiFolder> Folders = new List<SiFolder>();
            }
        }
        
        //[XmlRoot("File")]
        public class SiFile
        {
            //[XmlAttribute("Filename")]
            public string Filename { get; set; }
            //[XmlElement("Content")]
            public string Content { get; set; }
        }
        
        public class Write
        {
            static XmlWriter writer = null;
            public Write(string folderName,string readFilename)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                writer = XmlWriter.Create(readFilename, settings);
                writer.WriteStartDocument(true);
                writer.WriteStartElement("Plugin");
                DirectoryInfo info = new DirectoryInfo(folderName);
                WriteTree(info);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
                Console.WriteLine("Enter Return");
                Console.ReadLine();
            }
            static long WriteTree(DirectoryInfo info)
            {
                long size = 0;
                writer.WriteStartElement("Folders");
                try
                {
                    writer.WriteAttributeString("Name", info.Name);
                    writer.WriteAttributeString("NumberSubFolders", info.GetDirectories().Count().ToString());
                    writer.WriteAttributeString("NumberFiles", info.GetFiles().Count().ToString());
                    writer.WriteAttributeString("Date", info.LastWriteTime.ToString());
                    foreach (DirectoryInfo childInfo in info.GetDirectories())
                    {
                        size += WriteTree(childInfo);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = string.Format("Exception Folder : {0}, Error : {1}", info.FullName, ex.Message);
                    Console.WriteLine(errorMsg);
                    writer.WriteElementString("Error", errorMsg);
                }
                FileInfo[] fileInfo = null;
                try
                {
                    fileInfo = info.GetFiles();
                }
                catch (Exception ex)
                {
                    string errorMsg = string.Format("Exception FileInfo : {0}, Error : {1}", info.FullName, ex.Message);
                    Console.WriteLine(errorMsg);
                    writer.WriteElementString("Error", errorMsg);
                }
                if (fileInfo != null)
                {
                    writer.WriteStartElement("Files");
                    foreach (FileInfo finfo in fileInfo)
                    {
                        try
                        {
                            writer.WriteStartElement("File");
                            writer.WriteAttributeString("Name", finfo.Name);
                            writer.WriteAttributeString("Size", finfo.Length.ToString());
                            writer.WriteAttributeString("Date", info.LastWriteTime.ToString());
                            writer.WriteEndElement();
                            size += finfo.Length;
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = string.Format("Exception File : {0}, Error : {1}", finfo.FullName, ex.Message);
                            Console.WriteLine(errorMsg);
                            writer.WriteElementString("Error", errorMsg);
                        }
                    }
                    writer.WriteEndElement();
                }
                writer.WriteElementString("size", size.ToString());
                writer.WriteEndElement();
                return size;
            }
        }
    }
