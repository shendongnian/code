    [KnownType(typeof(Page))]
    [KnownType(typeof(Image))]
    [DataContract]
    public abstract class BaseContentObject { /* ... */ }
    [DataContract]
    public class Page : BaseContentObject { /* ... */ }
    [DataContract]
    public class Image : BaseContentObject { /* ... */ }
