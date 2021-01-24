    interface IDocumentTypes
    {
        string AString { get; set; } //indicates that both classes need to implement this
        //etc...
    }
    class DocumentTypeA : IDocumentTypes
    {
        //your class
    }
