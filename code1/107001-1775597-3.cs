    [Serializable]
    [XmlRoot("ToolBarConfiguration")]
    public class ToolBars
    {
        [XmlArray("ToolBars")]
        [XmlArrayItem("ToolBarSet", typeof(Toolbar))]
        public List<Toolbar> toolbars = new List<Toolbar>();
    }
    [Serializable]
    public class Toolbar
    {
        [XmlAttribute("id")]public int id;
        [XmlAttribute("buttonsCounter")]public int buttonsCounter;
        [XmlAttribute("width")]public int width;
        [XmlArray("ToolBarItems")]
        [XmlArrayItem("ToolBarItem", typeof(ToolbarItem))]
        public List<ToolbarItem> toolbarItems = new List<ToolbarItem>();
    }
    [Serializable]
    public class ToolbarItem
    {
        [XmlAttribute("Command")]public string command;
        [XmlAttribute("id")]public int id;
        [XmlAttribute("Icon")]public string icon;
        [XmlAttribute("Visible")]public bool visible;
        [XmlAttribute("Enabled")]public bool enabled;
    }
