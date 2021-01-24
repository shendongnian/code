    XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Result"); 
    string Short_Fall = string.Empty; 
    foreach (XmlNode node in nodeList) 
    { 
      Short_Fall = node.InnerText;
       if( Short_Fall == "insert result you are looking for")
           {
             //Where you want the print to happen comes below
             Console.WriteLine("True");
           }
          else
          {
             //Where you want the print to happen comes below
             Console.WriteLine("OK");
          }
    }
