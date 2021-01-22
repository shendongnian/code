class YourClass : IXmlSerializable
{
    public int? Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    //OTHER CLASS STUFF//
    #region IXmlSerializable members
    public void WriteXml (XmlWriter writer)
    {
        if( Age != null )
        {
            writer.WriteValue(writer)
        }
    }
    public void ReadXml (XmlReader reader)
    {
        Age = reader.ReadValue();
    }
    public XmlSchema GetSchema()
    {
        return(null);
    }
    #endregion
}
