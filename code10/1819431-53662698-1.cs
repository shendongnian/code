        public static List<string> SubDomains(this HttpRequest Request)
        {
            // variables
            string[] requestArray = Request.Host().Split(".".ToCharArray());
            var subDomains = new List<string>();
            // make sure this is not an ip address
            if (Request.IsIPAddress())
            {
                return subDomains;
            }
            // make sure we have all the parts necessary
            if (requestArray == null)
            {
                return subDomains;
            }
            // last part is the tld (e.g. .com)
            // second to last part is the domain (e.g. mydomain)
            // the remaining parts are the sub-domain(s)
            if (requestArray.Length > 2)
            {
                for (int i = 0; i <= requestArray.Length - 3; i++)
                {
                    subDomains.Add(requestArray[i]);
                }
            }
            // return
            return subDomains;
        }
        // e.g. www
        public static string SubDomain(this HttpRequest Request)
        {
            if (Request.SubDomains().Count > 0)
            {
                // handle cases where multiple sub-domains (e.g. dev.www)
                return Request.SubDomains().Last();
            }
            else
            {
                // handle cases where no sub-domains
                return string.Empty;
            }
        }
        // e.g. azurewebsites.net
        public static string Domain(this HttpRequest Request)
        {
            // variables
            string[] requestArray = Request.Host().Split(".".ToCharArray());
            // make sure this is not an ip address
            if (Request.IsIPAddress())
            {
                return string.Empty;
            }
            // special case for localhost
            if (Request.IsLocalHost())
            {
                return Request.Host().ToLower();
            }
            // make sure we have all the parts necessary
            if (requestArray == null)
            {
                return string.Empty;
            }
            // make sure we have all the parts necessary
            if (requestArray.Length > 1)
            {
                return $"{requestArray[requestArray.Length - 2]}.{requestArray[requestArray.Length - 1]}";
            }
            // return empty string
            return string.Empty;
        }
