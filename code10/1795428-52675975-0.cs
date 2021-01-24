    public class User
    {
        ...
        [InverseProperty( "User" )]
        public ICollection<UserProfile> UserProfiles { get; set; }
    }
