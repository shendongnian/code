        public class Document 
        { 
            public long DocumentId { get; set; } 
    
            public Metadata Metadata { get; set; } 
        }
    
        public class Metadata
        {
            
            public string DocumentType  { get; set; } 
    
            public DocumentType Type 
            {
                get
                {
                    return (DocumentType)Enum.Parse(typeof(DocumentType), DocumentType);
                }
            }
    
        }
    
        public enum DocumentType 
        { 
            DocumentType_A = 0, 
            DocumentType_B = 1, 
            DocumentType_C = 2 
        };
