            XElement doc = XElement.Load("testXML.xml");
            TreeNode stateNode;
            TreeNode regionNode;
            foreach (XElement state in doc.Descendants("State"))
            {
                stateNode = treeView1.Nodes.Add(state.Attribute("name").Value);
                foreach (XElement region in state.Descendants("Region"))
                {
                    regionNode =
                        stateNode.Nodes.Add(region.Attribute("name").Value);
                    foreach (XElement area in region.Descendants("Area"))
                    {
                        regionNode.Nodes.Add(area.Attribute("name").Value);
                    }
                }
            }
