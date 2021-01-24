    var root = doc.GetElementsByTagName("Head");
    var documents = new List<KeyValuePair<string, object>>();
    for (int i = 0; i < root.Count; i++)
    {
      for (int j = 0; j < root[i].ChildNodes.Count; j++)
      {
        var element = root[i].ChildNodes[j];
        MessageBox.Show(string.Format("element:{0}", element.InnerText));
        var document = new KeyValuePair<string, object>();
        document = new KeyValuePair<string, object>(element.Name, element.InnerText);
        documents.Add(document);
      }
    }
