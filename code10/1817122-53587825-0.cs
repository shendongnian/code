    public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
        {
            public override IdentityError DuplicateEmail(string email)
            {
                return new IdentityError
                {
                    Code = nameof(DuplicateEmail),
                    Description = string.Format(LocalizedIdentityErrorMessages.DuplicateEmail, email)
                };
            }
    
            public override IdentityError DuplicateUserName(string userName)
            {
                return new IdentityError
                {
                    Code = nameof(DuplicateUserName),
                    Description = string.Format(LocalizedIdentityErrorMessages.DuplicateUserName, userName)
                };
            }
    
            public override IdentityError InvalidEmail(string email)
            {
                return new IdentityError
                {
                    Code = nameof(InvalidEmail),
                    Description = string.Format(LocalizedIdentityErrorMessages.InvalidEmail, email)
                };
            }
    
            public override IdentityError DuplicateRoleName(string role)
            {
                return new IdentityError
                {
                    Code = nameof(DuplicateRoleName),
                    Description = string.Format(LocalizedIdentityErrorMessages.DuplicateRoleName, role)
                };
            }
    
            public override IdentityError InvalidRoleName(string role)
            {
                return new IdentityError
                {
                    Code = nameof(InvalidRoleName),
                    Description = string.Format(LocalizedIdentityErrorMessages.InvalidRoleName, role)
                };
            }
    
            public override IdentityError InvalidToken()
            {
                return new IdentityError
                {
                    Code = nameof(InvalidToken),
                    Description = LocalizedIdentityErrorMessages.InvalidToken
                };
            }
    
            public override IdentityError InvalidUserName(string userName)
            {
                return new IdentityError
                {
                    Code = nameof(InvalidUserName),
                    Description = string.Format(LocalizedIdentityErrorMessages.InvalidUserName, userName)
                };
            }
    
            public override IdentityError LoginAlreadyAssociated()
            {
                return new IdentityError
                {
                    Code = nameof(LoginAlreadyAssociated),
                    Description = LocalizedIdentityErrorMessages.LoginAlreadyAssociated
                };
            }
    
            public override IdentityError PasswordMismatch()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordMismatch),
                    Description = LocalizedIdentityErrorMessages.PasswordMismatch
                };
            }
    
            public override IdentityError PasswordRequiresDigit()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresDigit),
                    Description = LocalizedIdentityErrorMessages.PasswordRequiresDigit
                };
            }
    
            public override IdentityError PasswordRequiresLower()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresLower),
                    Description = LocalizedIdentityErrorMessages.PasswordRequiresLower
                };
            }
    
            public override IdentityError PasswordRequiresNonAlphanumeric()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresNonAlphanumeric),
                    Description = LocalizedIdentityErrorMessages.PasswordRequiresNonAlphanumeric
                };
            }
    
            public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresUniqueChars),
                    Description = string.Format(LocalizedIdentityErrorMessages.PasswordRequiresUniqueChars, uniqueChars)
                };
            }
    
            public override IdentityError PasswordRequiresUpper()
            {
                return new IdentityError
                {
                    Code = nameof(PasswordRequiresUpper),
                    Description = LocalizedIdentityErrorMessages.PasswordRequiresUpper
                };
            }
    
            public override IdentityError PasswordTooShort(int length)
            {
                return new IdentityError
                {
                    Code = nameof(PasswordTooShort),
                    Description = string.Format(LocalizedIdentityErrorMessages.PasswordTooShort, length)
                };
            }
    
            public override IdentityError UserAlreadyHasPassword()
            {
                return new IdentityError
                {
                    Code = nameof(UserAlreadyHasPassword),
                    Description = LocalizedIdentityErrorMessages.UserAlreadyHasPassword
                };
            }
    
            public override IdentityError UserAlreadyInRole(string role)
            {
                return new IdentityError
                {
                    Code = nameof(UserAlreadyInRole),
                    Description = string.Format(LocalizedIdentityErrorMessages.UserAlreadyInRole, role)
                };
            }
    
            public override IdentityError UserNotInRole(string role)
            {
                return new IdentityError
                {
                    Code = nameof(UserNotInRole),
                    Description = string.Format(LocalizedIdentityErrorMessages.UserNotInRole, role)
                };
            }
    
            public override IdentityError UserLockoutNotEnabled()
            {
                return new IdentityError
                {
                    Code = nameof(UserLockoutNotEnabled),
                    Description = LocalizedIdentityErrorMessages.UserLockoutNotEnabled
                };
            }
    
            public override IdentityError RecoveryCodeRedemptionFailed()
            {
                return new IdentityError
                {
                    Code = nameof(RecoveryCodeRedemptionFailed),
                    Description = LocalizedIdentityErrorMessages.RecoveryCodeRedemptionFailed
                };
            }
    
            public override IdentityError ConcurrencyFailure()
            {
                return new IdentityError
                {
                    Code = nameof(ConcurrencyFailure),
                    Description = LocalizedIdentityErrorMessages.ConcurrencyFailure
                };
            }
    
            public override IdentityError DefaultError()
            {
                return new IdentityError
                {
                    Code = nameof(DefaultError),
                    Description = LocalizedIdentityErrorMessages.DefaultIdentityError
                };
            }
        }
 
