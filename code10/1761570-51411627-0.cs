    try
            {
                var result = await Task.Run(() => _signInManager.PasswordSignInAsync(userName, password, isPersistent, true));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
