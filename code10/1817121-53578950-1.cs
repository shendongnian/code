    public class MyIdentityErrorDescriber : IdentityErrorDescriber
    {    
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = "Your description goes here."
            };
        }
    }
