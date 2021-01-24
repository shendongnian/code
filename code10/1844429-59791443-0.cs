    public class MessageBoard
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
    
            public ICollection<Message> Messages { get; set; }
        }
        
    public class Message
        {
            public long Id { get; set; }
            public string Text { get; set; }
            public string User { get; set; }
            public DateTime PostedDate { get; set; }
    
            public long MessageBoardId { get; set; }
            [ForeignKey("MessageBoardId")]
            public MessageBoard MessageBoard { get; set; } //This is the cause of your circular referece!!!
        }  
