    private bool isValid;
    private ArrayList exceptionList;
    public bool Validate()
    {
        isValid = true;
        exceptionList = new ArrayList();
        XmlTextReader reader;
        XmlSchema schema;
        XmlSchemaCollection schemas = new XmlSchemaCollection();
        reader = new XmlTextReader( "schema file 1" );
        schema = XmlSchema.Read( reader, new ValidationEventHandler( ValidationError ) );
        schemas.Add( schema );
        reader = new XmlTextReader( "schema file 2" );
        schema = XmlSchema.Read( reader, new ValidationEventHandler( ValidationError ) );
        schemas.Add( schema );
        reader = new XmlTextReader( "validate this file" );
        XmlValidatingReader validatingReader;
        validatingReader = new XmlValidatingReader( reader );
        validatingReader.ValidationEventHandler += new ValidationEventHandler( ValidationError );
        validatingReader.Schemas.Add( schemas );
        isValid = true;
        exceptionList = new ArrayList();
        while ( validatingReader.Read() );
        return isValid;
    }
    
    private void ValidationError( object sender, ValidationEventArgs e )
    {
        isValid = false;
        exceptionList.Add( e.Exception );
    }
