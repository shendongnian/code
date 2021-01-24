    // Gets or sets a delegate that will be used to validate the signature of the token.
    //
    // Remarks:
    //  If set, this delegate will be called to signature of the token, instead of normal
    //  processing.
    public SignatureValidator SignatureValidator { get; set; }
