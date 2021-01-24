    Entity.Property(E => E.NormalizedEmail)
    	.HasColumnName("NormalisedEmail")
    	.IsRequired();
    Entity.Property(E => E.NormalizedUserName)
    	.HasColumnName("NormalisedUserName");
