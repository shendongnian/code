    foreach (XmlNode book in root)
    {
        for (int i = 0; i < book.ChildNodes.Count; i++)
        {
            Console.WriteLine(root.ChildNodes[i].InnerText);
        }
    }
