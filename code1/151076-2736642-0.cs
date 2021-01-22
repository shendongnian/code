       static class Program
       {
          /// <summary>
          /// The main entry point for the application.
          /// </summary>
          [STAThread]
          static void Main()
          {
             Control Test = XMLParser.Parse("<Panel><Label>Text1</Label><Label>Text2</Label></Panel>");
             for (Int32 i = 0; i < Test.Controls.Count; i++)
             {
                System.Diagnostics.Debug.WriteLine("Control " + i + ": " + Test.Controls[i].GetType().FullName + " [TEXT = " + Test.Controls[i].Text + "]");
             }
          }
    
          static class XMLParser
          {
             public static Control Parse(string aXmlString)
             {
                Control result = null;
                using (StringReader strReader = new StringReader(aXmlString))
                {
                   using (XmlReader reader = XmlReader.Create(strReader))
                   {
                      result = ParseXML(reader);
                   }
                }
                return result;
             }
    
             public static Control ParseXML(XmlReader reader)
             {
                while (reader.Read())
                {
                   if (reader.NodeType == XmlNodeType.Element)
                   {
                      if (reader.LocalName == "Panel")
                      {
                         return ParsePanelElement(reader);
                      }
    
                      if (reader.LocalName == "Label")
                      {
                         return ParseLabelElement(reader);
                      }
                   }
                }
                return null;
             }
    
             private static Control ParsePanelElement(XmlReader reader)
             {
                var myPanel = new Panel();
                using (XmlReader subReader = reader.ReadSubtree())
                {
                   while (subReader.Read())
                   {
                      Control subControl = ParseXML(subReader);
                      if (subControl != null)
                      {
                         myPanel.Controls.Add(subControl);
                      };
                   }
                }
                return myPanel;
             }
    
             private static Control ParseLabelElement(XmlReader reader)
             {
                reader.Read();
                var myString = reader.Value as string;
                var myLabel = new Label();
                myLabel.Text = myString;
                return myLabel;
             }
          }
       }
