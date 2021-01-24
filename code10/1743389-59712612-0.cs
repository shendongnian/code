        public class CreateDocumentCommand : Command, ICreateDocumentCommand
        {
             public CreateDocumentCommand()
             {
             }
             [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
             public DocumentBase Document { get; set; }
        }
        public abstract class DocumentBase
        {
            public Guid Id { get; set; }
            public Guid AuthorId { get; set; }
            public abstract DateTime DateCreated { get; set; }
        }
         public class Document : DocumentBase
        {
            public override DateTime DateCreated { get; set; } = DateTime.Now;
        }
