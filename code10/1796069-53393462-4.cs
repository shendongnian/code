    public class ServiceAuthorizationManager : ServiceAuthorizationManager
        {
            protected override bool CheckAccessCore(OperationContext operationContext)
            {
                //Extract the Athorizationm Header,a nd parse out the credentials converting to base64 string
                var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                if ((authHeader != null) && (authHeader != string.Empty))
                {
                    var svcCredentials = System.Text.ASCIIEncoding.ASCII
                       .GetString(Convert.FromBase64String(authHeader.Substring(6)))
                       .Split(':');
                    return DefaultPasswordValidator.ValidateCridentials(svcCredentials[0], svcCredentials[1]);
                }
                else
                {
                    //No authorization header was provided, so challenge the client to provide before proceeding:
                    WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"UpdaterService\"");
                    //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                    throw new FaultException("Please provide a username and password");
                }
            }
