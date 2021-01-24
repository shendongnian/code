    public static XmlDocument GetParameterXML(string parameterFileName)
    {
        var sDllPath = AppDomain.CurrentDomain.BaseDirectory;
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(sDllPath + "\\Templates\\" + parameterFileName + ".xml");
    
        if (xDoc.DocumentType != null)
        {
            var name = xDoc.DocumentType.Name;
            var publicId = xDoc.DocumentType.PublicId;
            var systemId = xDoc.DocumentType.SystemId;
            var parent = xDoc.DocumentType.ParentNode;
            var documentTypeWithNullInternalSubset = xDoc.CreateDocumentType(name, publicId, systemId, null);
            parent.ReplaceChild(documentTypeWithNullInternalSubset, xDoc.DocumentType);
        }
    
        return xDoc;
    }
