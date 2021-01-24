        public bool ChangePassword(string userId, string newPassword)
            {
                _userManager.UserValidator = new UserValidator<IdentityUser>(_userManager) { AllowOnlyAlphanumericUserNames = false };
                var identityUser = _userManager.FindById(userId);
                identityUser.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);
                var result = _userManager.Update(identityUser);
                return true;
            }
