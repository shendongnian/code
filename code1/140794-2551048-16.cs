    public bool IsValidXmlEx(string strXmlLocation, string strXsdLocation)
    {
        bool bStatus = false;
        try
        {
            // Declare local objects
            XmlReaderSettings rs = new XmlReaderSettings();
            rs.ValidationType = ValidationType.Schema;
            rs.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation | XmlSchemaValidationFlags.ReportValidationWarnings;
            rs.ValidationEventHandler += new ValidationEventHandler(rs_ValidationEventHandler);
            rs.Schemas.Add(null, XmlReader.Create(strXsdLocation));
    
            using (XmlReader xmlValidatingReader = XmlReader.Create(strXmlLocation, rs))
            { while (xmlValidatingReader.Read()) { } }
    
            ////Exception if error.
            if (nErrors > 0) { throw new Exception(strErrorMsg); }
            else { bStatus = true; }//Success
        }
        catch (Exception error) { bStatus = false; }
    
        return bStatus;
    }
    
    void rs_ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning) strErrorMsg += "WARNING: " + Environment.NewLine;
        else strErrorMsg += "ERROR: " + Environment.NewLine;
        nErrors++;
        strErrorMsg = strErrorMsg + e.Exception.Message + "\r\n";
    }
