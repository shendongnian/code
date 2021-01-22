    public void Serialize(Basket b)
    {
        XElement _root = new XElement("Basket", 
            b.Select(
                f => new XElement("Fruit", 
                    new XText(f.Value))));
        _root.Save("file.xml");
    }
    public void Deserialize()
    {
        Basket b = new Basket();
        XElement _root = XElement.Load("file.xml");
        foreach(XElement fruit in _root.Descendants("Fruit"))
        {
            Fruit f = new Fruit();
            f.Value = fruit.Value;
            basket.Add(f);
        }
    }
