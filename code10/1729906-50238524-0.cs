    // persist in EF db context
    class Message {
        DateTime CreatedUtc { get; set; }
        DateTime SeenUtc { get; set; }
        string Text { get; set; }
        AspNetUser User { get; set; }
        // etc
    }
