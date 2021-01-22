    [ComVisible(true)]
    public interface IOurClass
    {
        IOurListObject[] OurCollection { get; }
    }
    
    public class OurClass : IOurClass
    {
        IOurListObject[] IOurClass.OurCollection { get { return OurCollection.ToArray();} }
    
        public ReadOnlyCollection<IOurListObject> OurCollection { ... }
    }
