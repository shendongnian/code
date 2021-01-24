    public override void OnActionExecuting(ActionExecutingContext context)
    {
      Claim claim = User.Claims
        .First(_ => _.Type == "MemberId");
      ...
    }
