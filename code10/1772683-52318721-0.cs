    @{  
    string userDesignation = ((ClaimsIdentity)User.Identity).FindFirst("OperationType").Value;
    string userImage = ((ClaimsIdentity)User.Identity).FindFirst("ImageLink").Value;
    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
    
        // Get the claims values
        var id= identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
            .Select(c => c.Value).SingleOrDefault();
        var s = id;
    //so on.......
    }
