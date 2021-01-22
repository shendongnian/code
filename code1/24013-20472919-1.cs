    public string CheckXmlCompatibleValues(string value)
        {
            string newValue = string.Empty;
            bool found = false;
            
            foreach (char c in value)
            {
                if (XmlConvert.IsXmlChar(c))
                    newValue += c.ToString();
                else
                    found = true;
            }
            return newValue.ToString();
        }
