    public class DocumentBaseMap : ClassMap<T> where T : DocumentOverview
    {
        public DocumentBaseMap()
        {
            Table("Documents");
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
        }
    }
    public class DocumentOverviewMap : DocumentBaseMap<DocumentOverview>
    {
    }
    
    public class DocumentMap : DocumentBaseMap<Document>
    {
        public DocumentMap() 
            : base()
        {
            Map(x => x.Data).CustomType<BinaryBlobType>().Nullable();
        }
    }
