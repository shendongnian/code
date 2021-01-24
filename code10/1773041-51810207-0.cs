                while (root.Read())
                {
                    if (root.NodeType != XmlNodeType.Element || 
                        root.Depth != 1 ||
                        root.Name != "node")
                        continue;
                    Console.WriteLine(root.GetAttribute("id"));
                }
