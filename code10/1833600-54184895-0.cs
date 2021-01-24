    var cislo = new List<string>();
    var zprava = new List<string>();
    XmlNodeList number = doc.GetElementsByTagName("SenderNumber");
    for (int i = 0; i < number.Count; i++)
    {
        cislo.Add(number[i].InnerXml);
    }
    XmlNodeList text = doc.GetElementsByTagName("TextDecoded");
    for (int i = 0; i < text.Count; i++)
    {
        zprava.Add(text[i].InnerXml);
    }
    MessageBox.Show(string.Join(", ", cislo));
    MessageBox.Show(string.Join(", ", zprava));
