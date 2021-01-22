    public string GetPickupDirectory()
    {
        var config = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
        return (config != null) ? config.SpecifiedPickupDirectory : null;
    }
