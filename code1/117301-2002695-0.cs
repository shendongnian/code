    public static void Save(ComboBox items) {
      XElement xmlElements = new XElement("Root");
      xmlElements.Add(
        items.Items
          .Cast<string>()
          .OrderBy(s => s)
          .Select(s => new XElement("Child", s))
          .ToArray()
      );
      xmlElements.Save("Output.xml");
    }
