    private Claim Claim { get; set; }
    public override void OnActionExecuting( ActionExecutingContext context )
    {
        this.Claim = GetClaim( int.Parse( context.RouteData["id"] ) );
        if (this.Claim == null)
        {
            context.Result = View( "ClaimNotFound" );
        }
    }
