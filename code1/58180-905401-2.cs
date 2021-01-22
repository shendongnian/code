    public XElement XmlHelpItem()
        {
            XElement helpitem = new XElement("HelpItem");
            XElement category = new XElement("Category", Category);
            XElement question = new XElement("Question", Question);
            XElement answer = new XElement("Answer", Answer);
            helpitem.Add(category);
            helpitem.Add(question);
            helpitem.Add(answer);
            return helpitem;
        }
