    private readonly EmailSettings _emailSettings;
    
    public EmailController(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
