        private static object syncLock = new object();
        private static Dictionary<String, object[]> lstCachedHashes = new Dictionary<String, object[]>();
        public static String ResolveStaticUrl(String staticFile, Boolean hashObject)
        {
            if (String.IsNullOrEmpty(staticFile))
                return "";
            String strFile = "";
            String strQuery = "";
            String strVirtualPath = "";
            String strPhysicalPath = "";
            int index = staticFile.IndexOf("?", StringComparison.OrdinalIgnoreCase);
            if (index == -1)
            {
                strFile = staticFile;
                strQuery = "";
            }
            else
            {
                strFile = staticFile.Substring(0, index);
                strQuery = staticFile.Substring(index + 1);
            }
            strVirtualPath = VirtualPathUtility.ToAbsolute(strFile);
            String strFileHash = "";
            if (hashObject)
            {
                strPhysicalPath = System.Web.Hosting.HostingEnvironment.MapPath(strFile);
                DateTime dteFileDate = DateTime.MinValue;
                if (lstCachedHashes.ContainsKey(strVirtualPath))
                {
                    object[] arr = lstCachedHashes[strVirtualPath];
                    // get from cache
                    dteFileDate = Convert.ToDateTime(arr[0], GenericFunctions.GetDefaultLocale());
                    strFileHash = Convert.ToString(arr[1], GenericFunctions.GetDefaultLocale());
                }
                else
                {
                    // only allow one thread at a time
                    lock (syncLock)
                    {
                        if (lstCachedHashes.ContainsKey(strVirtualPath))
                        {
                            object[] arr = lstCachedHashes[strVirtualPath];
                            // get from cache
                            dteFileDate = Convert.ToDateTime(arr[0], GenericFunctions.GetDefaultLocale());
                            strFileHash = Convert.ToString(arr[1], GenericFunctions.GetDefaultLocale());
                        }
                        else
                        {
                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(strPhysicalPath);
                            if (fileInfo.Exists)
                            {
                                dteFileDate = fileInfo.LastWriteTimeUtc;
                                strFileHash = CacheControl.GetFileHash(fileInfo);
                                // put in cache
                                lstCachedHashes.Add(strVirtualPath, new object[] { dteFileDate, strFileHash });
                            }
                        }
                    }
                }
            }
            // buildo PathAndQuery and return
            UriBuilder builder = new UriBuilder();
            builder.Path = strVirtualPath;
            builder.Query = strQuery;
            System.Collections.Specialized.NameValueCollection q = HttpUtility.ParseQueryString(builder.Query);
            if (string.IsNullOrEmpty(strFileHash) == false)
            {
                q.Add("v", strFileHash);
            }
            builder.Query = q.ToString();
            return builder.Uri.PathAndQuery;
        }
        public static String GetFileHash(System.IO.FileInfo fileInfo)
        {
            if ((fileInfo == null) || !fileInfo.Exists)
                return "";
            using (System.IO.FileStream stream = fileInfo.OpenRead())
            {
                using (System.Security.Cryptography.SHA256Managed sha = new System.Security.Cryptography.SHA256Managed())
                {
                    byte[] hash = sha.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            }
        }
