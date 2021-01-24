    using System.Xml.Linq;
    using System.Diagnostics;
    using static System.Windows.Forms.ListView;
    public static void SaveConfiguration(ListViewItemCollection items)
    {
        XDocument doc = new XDocument(new XElement("UABA",
        new XElement("Configure_Tab",
        new XElement("Actions_List"))));
        for (int i = 0; i < items.Count; i++)
        {
            doc.Element("UABA").Element("Configure_Tab").Element("Actions_List").Add(new XElement("ListItem_" + i, items[i].Checked));
                
            for (int j = 0; j < items[i].SubItems.Count; j++)
            {
                if (j == 0)
                    doc.Element("UABA").Element("Configure_Tab").Element("Actions_List").Element("ListItem_" + i).Add(new XAttribute("Position_X", items[i].SubItems[j].Text));
                if (j == 1)
                    doc.Element("UABA").Element("Configure_Tab").Element("Actions_List").Element("ListItem_" + i).Add(new XAttribute("Position_Y", items[i].SubItems[j].Text));
                if (j == 2)
                    doc.Element("UABA").Element("Configure_Tab").Element("Actions_List").Element("ListItem_" + i).Add(new XAttribute("RGB", items[i].SubItems[j].Text));
                if (j == 3)
                    doc.Element("UABA").Element("Configure_Tab").Element("Actions_List").Element("ListItem_" + i).Add(new XAttribute("Is_Colour", items[i].SubItems[j].Text));
                if (j == 4)
                    doc.Element("UABA").Element("Configure_Tab").Element("Actions_List").Element("ListItem_" + i).Add(new XAttribute("Target", items[i].SubItems[j].Text));
                if (j == 5)
                    doc.Element("UABA").Element("Configure_Tab").Element("Actions_List").Element("ListItem_" + i).Add(new XAttribute("Press_Button", items[i].SubItems[j].Text));
            }
        }
        doc.Save("MySettings.xml");
    }
