    using System; 
    using MyDomain.DBDecorations;
    
    namespace MyDomain.Entities {
        [Serializable]
        public class Message
        {
            public virtual string MessageId { get; set; }
    
            [StringLength(4000)] public virtual string Body { get; set; }
        }
    }
