    public class MagniAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        #region Allowed
        
        public bool IsPublic { get; set; }
        /// <summary>
        /// Comma seperated string of allowable IPs. Example "10.2.5.41,192.168.0.22"
        /// </summary>
        /// <value></value>        
        public string AllowedSingleIPs { get; set; }
        /// <summary>
        /// Comma seperated string of allowable IPs with masks. Example "10.2.0.0;255.255.0.0,10.3.0.0;255.255.0.0"
        /// </summary>
        /// <value>The masked I ps.</value>
        public string AllowedIPRanges { get; set; }
        /// <summary>
        /// Gets or sets the configuration key for allowed single IPs
        /// </summary>
        /// <value>The configuration key single I ps.</value>
        public string ConfigurationKeyAllowedSingleIPs { get; set; }
        /// <summary>
        /// Gets or sets the configuration key allowed mmasked IPs
        /// </summary>
        /// <value>The configuration key masked I ps.</value>
        public string ConfigurationKeyAllowedMaskedIPs { get; set; }
        
        #endregion
        #region Denied
        /// <summary>
        /// Comma seperated string of denied IPs. Example "10.2.5.41,192.168.0.22"
        /// </summary>
        /// <value></value>
        public string DeniedSingleIPs { get; set; }
        /// <summary>
        /// Comma seperated string of denied IPs with masks. Example "10.2.0.0;255.255.0.0,10.3.0.0;255.255.0.0"
        /// </summary>
        /// <value>The masked I ps.</value>
        public string DeniedIPRanges { get; set; }
        /// <summary>
        /// Gets or sets the configuration key for denied single IPs
        /// </summary>
        /// <value>The configuration key single I ps.</value>
        public string ConfigurationKeyDeniedSingleIPs { get; set; }
        /// <summary>
        /// Gets or sets the configuration key for denied masked IPs
        /// </summary>
        /// <value>The configuration key masked I ps.</value>
        public string ConfigurationKeyDeniedMaskedIPs { get; set; }
        
        #endregion
        /// <summary>
        /// Checks the allowed IPs.
        /// </summary>
        /// <param name="userIpAddress">The user ip address.</param>
        /// <returns></returns>
        private bool CheckAllowedIPs(IPAddress userIpAddress)
        {
            List<IPAddress> allowedIPsToCheck = new List<IPAddress>();
            List<IPAddressRange> allowedIPRangesToCheck = new List<IPAddressRange>();
            // Populate the IPList with the Single IPs
            if (!string.IsNullOrEmpty(AllowedSingleIPs))
            {
                SplitAndAddSingleIPs(AllowedSingleIPs, allowedIPsToCheck);
            }
            // Populate the IPList with the Masked IPs
            if (!string.IsNullOrEmpty(AllowedIPRanges))
            {
                SplitAndAddIPRanges(AllowedIPRanges, allowedIPRangesToCheck);
            }
            // Check if there are more settings from the configuration (Web.config)
            if (!string.IsNullOrEmpty(ConfigurationKeyAllowedSingleIPs))
            {
                string configurationAllowedAdminSingleIPs = ConfigurationManager.AppSettings[ConfigurationKeyAllowedSingleIPs];
                if (!string.IsNullOrEmpty(configurationAllowedAdminSingleIPs))
                {
                    SplitAndAddSingleIPs(configurationAllowedAdminSingleIPs, allowedIPsToCheck);
                }
            }
            if (!string.IsNullOrEmpty(ConfigurationKeyAllowedMaskedIPs))
            {
                string configurationAllowedAdminMaskedIPs = ConfigurationManager.AppSettings[ConfigurationKeyAllowedMaskedIPs];
                if (!string.IsNullOrEmpty(configurationAllowedAdminMaskedIPs))
                {
                    SplitAndAddIPRanges(configurationAllowedAdminMaskedIPs, allowedIPRangesToCheck);
                }
            }
            return allowedIPsToCheck.Any(a => a.Equals(userIpAddress)) || allowedIPRangesToCheck.Any(a => a.IsInRange(userIpAddress));
        }
        /// <summary>
        /// Checks the denied IPs.
        /// </summary>
        /// <param name="userIpAddress">The user ip address.</param>
        /// <returns></returns>
        private bool CheckDeniedIPs(IPAddress userIpAddress)
        {
            List<IPAddress> deniedIPsToCheck = new List<IPAddress>();
            List<IPAddressRange> deniedIPRangesToCheck = new List<IPAddressRange>();
            // Populate the IPList with the Single IPs
            if (!string.IsNullOrEmpty(DeniedSingleIPs))
            {
                SplitAndAddSingleIPs(DeniedSingleIPs, deniedIPsToCheck);
            }
            // Populate the IPList with the Masked IPs
            if (!string.IsNullOrEmpty(DeniedIPRanges))
            {
                SplitAndAddIPRanges(DeniedIPRanges, deniedIPRangesToCheck);
            }
            // Check if there are more settings from the configuration (Web.config)
            if (!string.IsNullOrEmpty(ConfigurationKeyDeniedSingleIPs))
            {
                string configurationDeniedAdminSingleIPs = ConfigurationManager.AppSettings[ConfigurationKeyDeniedSingleIPs];
                if (!string.IsNullOrEmpty(configurationDeniedAdminSingleIPs))
                {
                    SplitAndAddSingleIPs(configurationDeniedAdminSingleIPs, deniedIPsToCheck);
                }
            }
            if (!string.IsNullOrEmpty(ConfigurationKeyDeniedMaskedIPs))
            {
                string configurationDeniedAdminMaskedIPs = ConfigurationManager.AppSettings[ConfigurationKeyDeniedMaskedIPs];
                if (!string.IsNullOrEmpty(configurationDeniedAdminMaskedIPs))
                {
                    SplitAndAddIPRanges(configurationDeniedAdminMaskedIPs, deniedIPRangesToCheck);
                }
            }
            return deniedIPsToCheck.Any(a => a.Equals(userIpAddress)) || deniedIPRangesToCheck.Any(a => a.IsInRange(userIpAddress));
        }
        /// <summary>
        /// Splits the incoming ip string of the format "IP,IP" example "10.2.0.0,10.3.0.0" and adds the result to the IPAddress list
        /// </summary>
        /// <param name="ips">The ips.</param>
        /// <param name="list">The list.</param>
        private void SplitAndAddSingleIPs(string ips, List<IPAddress> list)
        {
            var splitSingleIPs = ips.Split(',');
            IPAddress ip;
            foreach (string ipString in splitSingleIPs)
            {
                if(IPAddress.TryParse(ipString, out ip))
                    list.Add(ip);
            }
        }
        /// <summary>
        /// Splits the incoming ip ranges string of the format "IP-IP,IP-IP" example "10.2.0.0-10.2.255.255,10.3.0.0-10.3.255.255" and adds the result to the IPAddressRange list
        /// </summary>
        /// <param name="ips">The ips.</param>
        /// <param name="list">The list.</param>
        private void SplitAndAddIPRanges(string ips, List<IPAddressRange> list)
        {
            var splitMaskedIPs = ips.Split(',');
            IPAddress lowerIp;
            IPAddress upperIp;
            foreach (string maskedIp in splitMaskedIPs)
            {
                var ipRange = maskedIp.Split('-');
                if (IPAddress.TryParse(ipRange[0], out lowerIp) && IPAddress.TryParse(ipRange[1], out upperIp))
                    list.Add(new IPAddressRange(lowerIp, upperIp));
            }
        }
        protected void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Home" },
                                                                                        { "Action", "Login" },
                                                                                        { "OriginalURL", context.HttpContext.Request.Url.AbsoluteUri } });
        }
        protected bool AuthorizeCore(AuthorizationContext context)
        {
            try
            {
                string userIPString = context.HttpContext.Request.UserHostName;
                IPAddress userIPAddress = IPAddress.Parse(userIPString);
                // Check that the IP is allowed to access
                bool? ipAllowed = CheckAllowedIPs(userIPAddress) ? true : (bool?)null;
                // Check that the IP is not denied to access
                ipAllowed = CheckDeniedIPs(userIPAddress) ? false : ipAllowed;
                if (ipAllowed.HasValue)
                {
                    return ipAllowed.Value;
                }
                var serverSession = context.HttpContext.Session;
                UserSession session = null;
                //usersession in server session
                if (serverSession[Settings.HttpContextUserSession] != null)
                {
                    session = (UserSession)serverSession[Settings.HttpContextUserSession];
                    Trace.TraceInformation($"[{MethodBase.GetCurrentMethod().Name}] UserId:" + session.UserId + ". ClientId: " + session.ClientId);
                    return true;
                }
                //usersession in database from cookie
                session = UserSession.GetSession(context.HttpContext.Request.Cookies.Get("sessionId").Value);
                if (session != null)
                {
                    Trace.TraceInformation($"[{MethodBase.GetCurrentMethod().Name}] Session found for cookie {context.HttpContext.Request.Cookies.Get("sessionId").Value}");
                    serverSession[Settings.HttpContextUserSession] = session;
                    Trace.TraceInformation($"[{MethodBase.GetCurrentMethod().Name}] UserId:" + session.UserId + ". ClientId: " + session.ClientId);
                    return true;
                }
                else
                {
                    Trace.TraceInformation($"[{MethodBase.GetCurrentMethod().Name}] No session found for cookie {serverSession["cookie"]}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"[{MethodBase.GetCurrentMethod().Name}] exception: {ex.Message} - trace {ex.StackTrace}");
                return false;
            }
        }
        public void OnAuthorization(AuthorizationContext actionContext)
        {
            if (IsPublic == false && AuthorizeCore(actionContext) == false)
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }
    }
