    /// <summary>Gets or sets a <see cref="T:System.Boolean" /> value that controls whether the <see cref="P:System.Net.CredentialCache.DefaultCredentials" /> are sent with requests.</summary>
    /// <returns>
    /// <see langword="true" /> if the default credentials are used; otherwise <see langword="false" />. The default value is <see langword="false" />.</returns>
    /// <exception cref="T:System.InvalidOperationException">You cannot change the value of this property when an e-mail is being sent.</exception>
    public bool UseDefaultCredentials
    {
      get
      {
        return this.transport.Credentials is SystemNetworkCredential;
      }
      set
      {
        if (this.InCall)
          throw new InvalidOperationException(SR.GetString("SmtpInvalidOperationDuringSend"));
        this.transport.Credentials = value ? (ICredentialsByHost) CredentialCache.DefaultNetworkCredentials : (ICredentialsByHost) null;
      }
    }
