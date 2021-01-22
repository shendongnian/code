    foreach (var PharosUserItem in ListRef)
        {
            ADUser User;
            try
            {
                User = new ADUser(PharosUserItem.UserLoginPharos);
            }
            catch (ByTel.DirectoryServices.Exceptions.UserNotFoundException ex)
            {
                continue;
            }
        }
