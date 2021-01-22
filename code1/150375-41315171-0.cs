    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;
    
    namespace WindowsFormsApplication_DynamicGUIFromXML
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            XDocument guiConfig = XDocument.Load(@"../../Gui.xml");
            foreach (XElement item in from y in guiConfig.Descendants("Item") select y)
            {
                Control tmp = new Control();
                switch (item.Attribute("type").Value)
                {
                    case "Button":
                        tmp = new Button();
                        break;
                    case "TextBox":
                        tmp = new TextBox();
                        break;
                }
                tmp.Name = item.Attribute("name").Value;
                tmp.Text = item.Attribute("text").Value;
                tmp.Location = new Point(Int32.Parse(item.Attribute("x").Value), Int32.Parse(item.Attribute("y").Value));
                Controls.Add(tmp);
            }
        }
        }
     }
    // ***********************************************
    // Contents of Gui.xml
    // ***********************************************
    //<?xml version="1.0" encoding="utf-8" ?>
    //<Gui>
    //  <Item type="Button" name="foo" text="bar" x="100" y="100"  />
    //  <Item type="TextBox" name="foo2" text="bar2" x="200" y="200"  />
    //</Gui>
    // ***********************************************
