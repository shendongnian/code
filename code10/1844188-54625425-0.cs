       try
                {
                    appUser.personInfo.FirstName = appUser.FirstName;
                    appUser.personInfo.LastName = appUser.LastName;
                    appUser.personInfo.EmailAddress = appUser.Email;
                    await _userManager.UpdateAsync(appUser); 
                    await aspnetdBContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
    
                }
