    ..
    var element = root[i].ChildNodes[j];
    MessageBox.Show(string.Format("element:{0}", element.InnerText));
    
    string numbers = string.Empty;
    for(int z = 0; z < element.ChildNodes.Count; z++)
    {
      numbers += element.ChildNodes[z].InnerText + Environment.NewLine;
    }
    
    var document = new KeyValuePair<string, object>(element.Name, numbers);
    documents.Add(document);
    ..
