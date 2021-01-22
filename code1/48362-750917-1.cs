    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    foreach (XmlElement el in doc.SelectNodes("//responce")) {
        Console.WriteLine(el.ParentNode.Name + "=" + el.InnerText);
    }
    XmlNodeList fiveAnswers = doc.SelectNodes(
          "/Survey/ClientResponces/Question5/*/responce");
    double avg = fiveAnswers.Cast<XmlElement>()
         .Average(el => int.Parse(el.InnerText));
    Console.WriteLine(avg);
