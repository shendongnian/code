    if (context.IsEncrypting)
    {
        crypt = context.Encryption;
        if (!ShouldBeEncrypted(crypt))
        {
            context.SuspendEncryption();
            suspendedEncryption = true;
        }
    }
    // ... more code ...
    if (suspendedEncryption)
    {
        context.ResumeEncryption();
    }
