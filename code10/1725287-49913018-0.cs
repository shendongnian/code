            ApplicationUser user = new ApplicationUser
            {
                Email = workTimeEvent.Email
            }; 
            
            // query db to check if user does exist but you do not retrieve it
            if (db.Users.Where(x => x.Email == workTimeEvent.Email).Count() == 1)
            {
                var result = ph.VerifyHashedPassword(user.PasswordHash, workTimeEvent.Password);
                if (result == PasswordVerificationResult.Success)
