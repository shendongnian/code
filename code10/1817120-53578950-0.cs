    public class IdentityErrorDescriber
    {
        ...
    
        public virtual IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = Resources.FormatPasswordTooShort(length)
            };
        }
    
    
        ...
    }
