    // Attachment field has no validation - any attachment would work
    public AwaitableAttachment BestImage;
    // Attachment field is optional - validation is done through AttachmentContentTypeValidator usage
    [Optional]
    [AttachmentContentTypeValidator(ContentType = "png")]
    public AwaitableAttachment SecondaryImage;
