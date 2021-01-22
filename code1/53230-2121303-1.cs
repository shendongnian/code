            /// <summary>
            /// Builds a complete http url with query strings.
            /// </summary>
            /// <param name="pHostname"></param>
            /// <param name="pPort"></param>
            /// <param name="pPage">ex "/index.html" or index.html</param>
            /// <param name="pGetParams">a Dictionary<string,string> collection containing the key value pairs.  Pass null if there are none.</param>
            /// <returns>a string of the form: http://[pHostname]:[pPort/[pPage]?key1=val1&key2=val2...</returns>
      static public string buildURL(string pHostname, int pPort, string pPage, Dictionary<string,string> pGetParams)
            {
                StringBuilder sb = new StringBuilder(200);
                sb.Append("http://");
                sb.Append(pHostname);
                if( pPort != 80 ) {
                    sb.Append(pPort);
                }
                // Allows page param to be passed in with or without leading slash.
                if( !pPage.StartsWith("/") ) {
                    sb.Append("/");
                }
                sb.Append(pPage);
                            
                if (pGetParams != null && pGetParams.Count > 0)
                {
                    sb.Append("?");
                    foreach (KeyValuePair<string, string> kvp in pGetParams)
                    {
                        sb.Append(kvp.Key);
                        sb.Append("=");
                        sb.Append( System.Web.HttpUtility.UrlEncode(kvp.Value) );
                        sb.Append("&");
                    }
                    sb.Remove(sb.Length - 1, 1); // Remove the final '&'
                }
                return sb.ToString();
            }
