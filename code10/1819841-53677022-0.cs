    public void Process(DtoPostType source, EntityType destination)
    {
        destination.CreatedUser = 
            (_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity)?.Name;
    }
