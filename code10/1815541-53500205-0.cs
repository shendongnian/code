    static void Main(string[] args)
        {
            FolderBrowserDialog SelectFolder = new FolderBrowserDialog();
            String path = @"C:\newpages";
    
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Pages");
    
            if (SelectFolder.ShowDialog() == DialogResult.OK)
            {
                var txt = string.Empty;
                string[] Files = Directory.GetFiles((SelectFolder.SelectedPath));
    
                int i = 1;
                foreach (string path1 in Files)
                {
                    String filename = Path.GetFileNameWithoutExtension((path1));
    
                    if (!filename.Contains(".0"))
                    {
                        using (StreamReader sr = new StreamReader(path1))
                        {
                            txt = sr.ReadToEnd();
                            XmlElement id = doc.CreateElement("Page.id");
                            id.SetAttribute("Page.Nr", i.ToString());
                            id.SetAttribute("Pagetitle",  filename);
                            XmlElement name = doc.CreateElement("PageContent");
                            XmlCDataSection cdata = doc.CreateCDataSection(txt);
                            name.AppendChild(cdata);
                            id.AppendChild(name);  // page id appenndchild         
                            root.AppendChild(id);  // roots appenedchild
                            doc.AppendChild(root); //Main root
    
                        }
    
                    }
                   
                    
                 i++;
                }
            }
            Console.WriteLine("finished");
            Console.ReadKey();
    
            doc.Save(Path.ChangeExtension(path, ".xml"));
    
        }
