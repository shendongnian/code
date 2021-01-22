    XElement ops = XElement.Load(@"c:\temp\exp.xml");
    Tree<Element> domain = new Tree<Element>(
        from cell in ops.Elements("cell")
        select new TreeNode<Element>(
            new Cell(
                (string)cell.Attribute("name"),
                (string)cell.Attribute("name"), null
            ),
            from agent in cell.Elements("agent")
            select new TreeNode<Element>(
                new Agent(
                    (string)agent.Attribute("name"),
                    (string)agent.Attribute("name"), null
                ),
                from na in agent.Elements("node-agent")
                select new TreeNode<Element>(
                    new NodeAgent(
                        (string)na.Attribute("name"),
                        (string)na.Attribute("name"), null)
                    )
                )
            )
        );
