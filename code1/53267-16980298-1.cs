        public static string ToQueryString(System.Collections.Specialized.NameValueCollection nvc)
        {
            List<string> lsParams = new List<string>();
            
            foreach (string strKey in nvc.AllKeys)
            {
                string[] astrValue = nvc.GetValues(strKey);
                foreach (string strValue in astrValue)
                {
                    lsParams.Add(string.Format("{0}={1}", System.Web.HttpUtility.UrlEncode(strKey), System.Web.HttpUtility.UrlEncode(strValue)));
                } // Next strValue
            } // Next strKey
            string[] astrParams =lsParams.ToArray();
            lsParams.Clear();
            lsParams = null;
            return "?" + string.Join("&", astrParams);
        } // End Function ToQueryString
