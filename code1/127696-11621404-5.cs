    // Acts as a collection of SpecificRow objects, which inherit from Row.  Uses the same
    // Collection<Row> that Rows defines which is fine since SpecificRow : Row.
    [Serializable]
    [XmlRoot("MySpecificRowList")]
    public class SpecificRows : Rows, IXmlSerializable
    {
        protected override Row CreateRow()
        {
            return new SpecificRow();
        }   
    }
