    public void WriteXml (XMLWriter writer)
    {
        if( Age != null )
        {
            writer.WriteValue( age );
        }
    }
