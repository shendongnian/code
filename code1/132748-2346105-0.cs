    try
    {
        System.Xml.Serialization.XmlSerializer serializer = 
            new XmlSerializer(typeof(Catalog));
        this._catfileStream.SetLength(0); //clears the file stream
        serializer.Serialize(this._catfileStream, this);
    }
    // catch (InvalidOperationException exp)
    // Don't catch this because I have nothing specific to add that 
    // I wouldn't also say for all exceptions.
    catch (Exception exp)
    {
        throw new CatalogIOException(
            string.Format("There was a problem accessing catalog file '{0}'. ({1})",
                _catfileStream.Name, exp.Message), exp);
    }
