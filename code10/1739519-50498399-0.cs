    internal void AssertPolicyIfRequired()
    {
        if (this.RequireEncryption.HasValue && this.RequireEncryption.Value && this.EncryptionPolicy == null)
        {
              throw new InvalidOperationException(SR.EncryptionPolicyMissingInStrictMode);
        }
    }
