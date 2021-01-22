    public class AuthenticationContext : IWMSAuthenticationContext
    {
    #region IWMSAuthenticationContext Members
    private WMS_AUTHENTICATION_RESULT _result;
    private readonly IWMSAuthenticationPlugin _plugin;
    private Credentials _credentials;
    private IntPtr _userToken;
    public AuthenticationContext(IWMSAuthenticationPlugin plugin)
    {
        _plugin = plugin;
    }
    public void Authenticate(object responseBlob, IWMSContext pUserCtx, IWMSContext pPresentationCtx, IWMSCommandContext pCommandContext, IWMSAuthenticationCallback pCallback, object context)
    {
        // must be Unicode.  If it isn't, the 
        // challenge isn't sent correctly
        Encoding enc = Encoding.Unicode;
        byte[] response;
        byte[] challenge = enc.GetBytes("");
        try
        {
            response = (byte[])responseBlob;
            if (response.Length == 0)
            {
                // The client requested authentication; prepare the
                // challenge response to send to the client.  In order to 
                // do Basic authentication, be sure to return "Basic" from 
                // your implementation of IWMSAuthenticationPlugin.GetProtocolName()
                string challengeTxt = "WWW-Authenticate: Basic realm=\"Domain\"";
                challenge = enc.GetBytes(challengeTxt);
                _result = WMS_AUTHENTICATION_RESULT.WMS_AUTHENTICATION_CONTINUE;
            }
            else
            {
                // parses Base64 encoded response and gets passed in credentials
                SetCredentials(enc.GetString(response));
                LdapConnection ldc = new LdapConnection("Domain");
                NetworkCredential nc = new NetworkCredential(_credentials.Username, _credentials.Password, "Domain");
                ldc.Credential = nc;
                ldc.AuthType = AuthType.Negotiate;
                ldc.Bind(nc); // user has authenticated at this point, as the credentials were used to login to the dc.
                // must log in with a local windows account and get a handle for the account.
                // even if success is returned, the plugin still needs a valid windows account
                // to stream the file.                    
                bool result = LogonAPI.LogonUser("local username", "local domain", "local password", LogonAPI.LOGON32_LOGON_NETWORK, LogonAPI.LOGON32_PROVIDER_DEFAULT, ref _userToken);
                _result = WMS_AUTHENTICATION_RESULT.WMS_AUTHENTICATION_SUCCESS;
            }
        }
        catch (LdapException e)
        {
            _result = WMS_AUTHENTICATION_RESULT.WMS_AUTHENTICATION_DENIED;
        }
        catch (Exception e)
        {
            _result = WMS_AUTHENTICATION_RESULT.WMS_AUTHENTICATION_ERROR;
        }
        finally
        {
            pCallback.OnAuthenticateComplete(_result, challenge, context);
        }
    }
    public IWMSAuthenticationPlugin GetAuthenticationPlugin()
    {
        return _plugin;
    }
    public string GetImpersonationAccountName()
    {
        return "Domain\\" + _credentials.Username;
    }
    public int GetImpersonationToken()
    {
        // somehow the plugin knows how this integer ties to a windows account.
        return _userToken.ToInt32();
    }
    public string GetLogicalUserID()
    {
        return GetImpersonationAccountName();
    }
    public void SetCredentials(string responseStr)
    {
        // for whatever reason, the responseStr has an extra character
        // tacked on the end that blows up the conversion.  When converting
        // from the Base64 string, remove that last character.
        string decoded = new UTF8Encoding().GetString(Convert.FromBase64String(responseStr.Substring(0, responseStr.Length - 1)));
        
        // now that the string has been decoded and is now in the format
        // username:password, parse it further into a Username and Password 
        // struct.
        _credentials = new Credentials(decoded);
    }
    #endregion
    }
