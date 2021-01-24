            ApplicationUser user = new ApplicationUser
            {
                Email = workTimeEvent.Email
            }; 
            
            // query db to check if user does exist but you do not retrieve it
            var dbUser = db.Users.FirstOrDefault(x => x.Email == workTimeEvent.Email);
            
            if (dbUser != null)
            {
                var result = ph.VerifyHashedPassword(dbUser.PasswordHash, workTimeEvent.Password);
                if (result == PasswordVerificationResult.Success)
