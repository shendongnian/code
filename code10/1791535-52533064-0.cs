    var xmlDocument = XDocument.Load(@"data\tools.xml");
        var ToolData = from r in xmlDocument.Descendants("ToolClass").Where
                       (r => (string)r.Element("ToolID").Value == ToolListComboBox.SelectedValue.ToString())
                       select new
                       {
                           Tooldia = r.Element("ToolDia").Value,
                           Tooltooth = r.Element("ToolTooth").Value,
                           Toolfeed= r.Element("ToolFeedPerTooth").Value,
                           Toolcut = r.Element("ToolCuttingSpeed").Value                               
                       };
        foreach(var r in ToolData)
        {
            CalcToolDia.Text = r.Tooldia.ToString();
        }
