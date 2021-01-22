    catch(DirectoryServicesCOMException exc)
    {
        if((uint)exc.ExtendedError == 0x80090308)
        {
            LDAPErrors errCode = 0;
            try
            {
                // Unfortunately, the only place to get the LDAP bind error code is in the "data" field of the 
                // extended error message, which is in this format:
                // 80090308: LdapErr: DSID-0C09030B, comment: AcceptSecurityContext error, data 52e, v893
                if(!string.IsNullOrEmpty(exc.ExtendedErrorMessage))
                {
                    Match match = Regex.Match(exc.ExtendedErrorMessage, @" data (?<errCode>[0-9A-Fa-f]+),");
                    if(match.Success)
                    {
                        string errCodeHex = match.Groups["errCode"].Value;
                        errCode = (LDAPErrors)Convert.ToInt32(errCodeHex, fromBase: 16);
                    }
                }
            }
            catch { }
            switch(errCode)
            {
                case LDAPErrors.ERROR_PASSWORD_EXPIRED:
                case LDAPErrors.ERROR_PASSWORD_MUST_CHANGE:
                    throw new Exception("Your password has expired and must be changed.");
                // Add any other special error handling here (account disabled, locked out, etc...).
            }
        }
        // If the extended error handling doesn't work out, just throw the original exception.
        throw;
    }
