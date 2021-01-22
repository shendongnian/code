    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            textBox1.AppendText(nameAttributeCheck(comboBox1.SelectedItem.ToString()));
        }
        catch { 
        }
    }
    private string nameAttributeCheck(string a)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("armor.xml");
        XmlElement root = doc.DocumentElement;
        XmlNodeList items = root.SelectNodes("/items/item");
        
        String result = null;
        try
        {
                for (int i = 0; i < items.Count; i++)
                {
                    
                    if (string.Equals(a, items[i].Attributes["name"].InnerText.ToString()))
                    {
                        result += items[i].Attributes["name"].InnerText.ToString();
                    }
                }               
        }
        catch
        {
        }
        return result;
    }
