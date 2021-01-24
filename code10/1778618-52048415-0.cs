            var clients = new List<Client>(myService.myContext.Clients);
            foreach (var client in clients)
            {
                var user = new ApplicationUser // Derived from IdentityUser
                {
                    UserID = client.UserID,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    UserName = client.UserName,
                    PhoneNumber = client.Phone,
                    Email = client.Email         // Other fields omitted for brevity.
                };
                var idUser = user as IdentityUser;
                client.AspIdentityId = user.Id;
                client.ConcurrencyStamp = user.ConcurrencyStamp;
                client.NormalizedEmail = user.NormalizedEmail;
                client.NormalizedUserName = user.NormalizedUserName;
                client.PasswordHash = user.PasswordHash;
                client.SecurityStamp = user.SecurityStamp;
                myService.myContext.SaveChanges();
                // Can we just use the 'user' object here?
                var newUser = await myService.UserManager.FindByIdAsync(client.AspIdentityId);
                var result = await myService.UserManager.AddPasswordAsync(newUser, client.Password);
           }
