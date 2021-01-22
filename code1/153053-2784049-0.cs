    class AuthInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    class AuthInfoValidator : AbstractValidator<AuthInfo>
    {
        public override ValidationResult Validate(AuthInfo instance)
        {
            var result = base.Validate(instance);
            if (string.IsNullOrEmpty(instance.Username))
            {
                result.Errors.Add(new ValidationFailure("Username", "Username is required"));
            }
            if (string.IsNullOrEmpty(instance.Password))
            {
                result.Errors.Add(new ValidationFailure("Password", "Password is required"));
            }
            if (string.IsNullOrEmpty(instance.ConfirmPassword))
            {
                result.Errors.Add(new ValidationFailure("ConfirmPassword", "ConfirmPassword is required"));
            }
            if (instance.Password != instance.ConfirmPassword)
            {
                result.Errors.Add(new ValidationFailure("ConfirmPassword", "Passwords must match"));
            }
            return result;
        }
    }
