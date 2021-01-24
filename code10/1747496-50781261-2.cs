    public static object GetService(Type requestedType)
    {
        if (requestedType == typeof(IMessageService))
        {
            return new EmailService();
        }
        else
        {
            return null;
        }
    }
