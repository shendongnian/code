    var xs = new XmlSerializer(typeof(Result));
    xs.UnknownElement += Xs_UnknownElement;
    private static void Xs_UnknownElement(object sender, XmlElementEventArgs e)
    {
        if (e.Element.Name == "service")
        {
            var result = (Result)e.ObjectBeingDeserialized;
            if (e.Element.ChildNodes.Count == 1)
            {
                result.ServiceSimple = e.Element.InnerText;
            }
            else
            {
                result.ServiceComplex = new ServiceComplex
                {
                    Min_amount = e.Element.SelectSingleNode("min_amount").InnerText,
                    Max_amount = e.Element.SelectSingleNode("max_amount").InnerText,
                    Currency = e.Element.SelectSingleNode("currency").InnerText
                };
            }
        }
    }
