            public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if(user == null)
            return null;
            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;
            return user;
        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmaic = new System.Security.Cryptography.HMACSHA512())
            {
              passwordSalt = hmaic.Key;
              passwordHash = hmaic.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
           using (var hmaic = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {             
              var computedHash = hmaic.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
              for(int i =0; i < computedHash.Length; i++)
              {
                  if(computedHash[i] != passwordHash[i])
                  return false;
              }
              return true;
            }
            
        }
