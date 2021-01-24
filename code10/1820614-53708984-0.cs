    static byte[] EditFieldXFAImproved(string path, string xpath, string value)
    {
        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(path);
        using (MemoryStream ms = new MemoryStream())
        {
            PdfStamper stamper = new PdfStamper(reader, ms);
            AcroFields form = stamper.AcroFields;
            XfaForm xfa = form.Xfa;
            XmlNode a = xfa.DatasetsNode;
            XmlNodeList hits = a.SelectNodes(xpath);
            foreach(XmlNode hit in hits)
            {
                if (hit.NodeType == XmlNodeType.Element)
                {
                    hit.InnerText = value;
                }
            }
            xfa.Changed = true;
            stamper.Close();
            reader.Close();
            return ms.ToArray();
        }
    }
