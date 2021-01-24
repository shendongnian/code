    private void MainForm_Load(object sender, EventArgs e)
        {
            int cusLooper = 0;
            int assyLooper = -1;
            
            //Load xml
            XmlDocument db = new XmlDocument();
            db.Load("XML Template.xml");
            XmlNodeList nl = db.GetElementsByTagName("Customer");
            foreach (XmlNode node in nl)
            {
                XmlNode element = node;
                foreach(XmlNode node2 in node)
                {
                    XmlNode node3 = node2;
                    if (node2.Name == "Name")
                    {
                        treeView1.Nodes.Add(node3.InnerText);
                        assyLooper = -1;
                    }
                    foreach (XmlNode node4 in node3)
                    {
                        if (node4.Name == "AssemblyNumber")
                        {
                            treeView1.Nodes[cusLooper].Nodes.Add(node4.InnerText);
                            assyLooper++;
                        }
                        if (node4.Name == "Part")
                        {
                            XmlNode element2 = node4;
                            foreach (XmlNode final in element2)
                            {
                                if (final.Name == "PartNumber")
                                {
                                    TreeNode nd = treeView1.Nodes[cusLooper].Nodes[assyLooper].Nodes.Add(final.InnerText);
                                    nd.ImageIndex = 7;
                                    nd.SelectedImageIndex = nd.ImageIndex;
                                }
                                
                            }
                            //assyLooper++;
                        }
                        
                    }
                    
                }
                cusLooper++;
            }
        }
