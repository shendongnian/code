    XmlDocument buildDocument(Control control)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.AppendChild(xmlDoc.CreateElement("Form"));
        buildDocumentRecursive(xmlDoc, control);
        return xmlDoc;
    }
    void buildDocumentRecursive(XmlDocument xmlDoc, Control control)
    {
        var textCtrl = control as IEditableTextControl;
        if (textCtrl != null)
        {
            var element = xmlDoc.CreateElement(control.ClientID);
            element.InnerText = textCtrl.Text;
            xmlDoc.DocumentElement.AppendChild(element);
        }
        // If you want to check for check boxes, radio buttons, etc., add other cases
        else
        {
            foreach (var child in control.Controls)
            {
                buildDocumentRecursive(xmlDoc, child);
            }
        }
    }
