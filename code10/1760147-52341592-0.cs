        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);
            var userToVerify = await _userManager.FindByNameAsync(userName);                
            if (userToVerify == null) {
                userToVerify = await _userManager.FindByEmailAsync(userName);
                if (userToVerify == null)  {
                    return await Task.FromResult<ClaimsIdentity>(null);
                }
            }
            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                _claims = await _userManager.GetClaimsAsync(userToVerify);
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userToVerify.UserName, userToVerify.Id, _claims));
            }
            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
