    // The property name is "FeedbackComment"
    public string FeedbackComment
    {
        // And here you are returning "FeedbackComment" which is
        // creating the stack overflow
        get { return FeedbackComment; }
    }
