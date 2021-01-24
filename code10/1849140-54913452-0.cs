            var data = await m_service.CreateAsync(new Customer
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                },
                new CustomerCreateOptions
                {
                    SendEmailInvite = false,
                    SendWelcomeEmail = false,
                    Password = password,
                    PasswordConfirmation = password
                });
