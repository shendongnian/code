    // Wrap the string value into a DTO and inject that
    public EmailService(
        EmailServiceSettings settings, IEventEmailTemplatesRepository r) { ... }
    container.RegisterInstance(new EmailServiceSettings(emailTemplates));
    container.Register<IEmailService, EmailService>();
