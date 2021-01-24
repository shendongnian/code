    private readonly ITokenProvider tokenProvider;
    public NozzleAdapter(ITokenProvider tokenProvider)
    {
       tokenProvider=tokenProvider;
    }
    public string SomeOtherMethod()
    {
       var token = this.tokenProvider.GetToken();
       //Do null check and use it
    }
