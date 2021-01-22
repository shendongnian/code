    public void CommaSeperatedWriteLine(TextWriter sw, params Object[] list)
    {
        if (list.Length > 0)
        {
            System.Configuration.CommaDelimitedStringCollection commaStr = new System.Configuration.CommaDelimitedStringCollection();
            foreach (Object obj in list)
            {
                commaStr.Add(obj.ToString());
            }
            sw.WriteLine(commaStr.ToString());
        }
    }
