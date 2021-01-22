        string strXML = @"<root>
            <item parent_id='0' id='1'><content><name>Peter Smith</name></content></item>
            <item parent_id='1' id='2'><content><name>Mary Jane</name></content></item>
            <item parent_id='1' id='7'><content><name>Lucy Lu</name></content></item>
            <item parent_id='2' id='3'><content><name>Informatics Team</name></content></item>
            <item parent_id='3' id='4'><content><name>Sandy Chu</name></content></item>
            <item parent_id='4' id='5'><content><name>John Smith</name></content></item>
            <item parent_id='5' id='6'><content><name>Jane Smith</name></content></item>
            </root>";
        XDocument xDoc = XDocument.Parse(strXML, LoadOptions.None);
        var objData = xDoc.Root.Elements("item").ToList().Select(item =>
            new { id = item.Attribute("id").Value,
                  pid = item.Attribute("parent_id").Value,
                  tn = new TreeNode(item.Element("content").Element("name").Value)
            }).ToList();
        objData.ForEach(child =>
            {
                var parent = objData.FirstOrDefault(m => m.id == child.pid);
                if (parent != null)
                    parent.tn.Nodes.Add(child.tn);
            });
        // Add all nodes with no parent to the TreeView's root:
        objData.Where(n => n.tn.Parent == null).ToList().ForEach(n => treeView1.Nodes.Add(n.tn));
