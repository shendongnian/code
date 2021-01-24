    // inject via using Microsoft.AspNetCore.Identity
    protected ILookupNormalizer normalizer;
    var appUsers = users.Select(x => new ApplicationUser
    {
        Email = x.email,
        NormalizedEmail = normalizer.Normalize(x.email),
        NormalizedUserName = normalizer.Normalize(x.email),
        UserName = x.email,
        EmailConfirmed = true,
        Id = Guid.NewGuid().ToString(),
        SecurityStamp = Guid.NewGuid().ToString()
    }).ToArray();
