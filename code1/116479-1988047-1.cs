    private void add(object sender, RoutedEventArgs e)
    {
	    System.Xml.XmlNode test = configfile.Document.DocumentElement["Components"].FirstChild;
	    System.Xml.XmlNode testclone = test.Clone();
	    for (int i = 0; i < testclone.ChildNodes.Count; i++)
	    {
    		testclone.ChildNodes[i].RemoveAll();
	    }
	    configfile.Document.DocumentElement["Components"].AppendChild(testclone);
	    components.SelectedItem = components.Items.Count + 1;
    }
