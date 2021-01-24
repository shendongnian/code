    IEnumerable<String> userRoles = this.GetIdentityUserRoles();
    property.ShouldSerialize = instance =>
    {
        // Check if every attribute instance has at least one role listed in the user's roles.
        return attrs.All(attr =>
                    userRoles.Any(ur =>
                        attr.AllowedRoles.Any(ar => 
                            String.Equals(ar, ur, StringComparison.OrdinalIgnoreCase)))
        );
    };
