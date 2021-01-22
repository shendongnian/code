        /// <summary>
        /// Alters the current HTTP request only for Android user agents, in order to disable web page compression so the Android browser will not cut off most of the page content, based on the Content-length HTTP header. 
        /// </summary>
        public static void fixAndroidPageDisplay()
        {
            HttpContext c = HttpContext.Current;
            if (c == null) return;
            HttpRequest r = c.Request;
            if (r == null || r.UserAgent == null) return;
            if (r.UserAgent.ToLowerInvariant().Contains("android"))
            {
                HttpResponse rsp = c.Response;
                
                if (rsp != null)
                {
                    string ce = null;
                    foreach (string s in rsp.Headers.Keys)
                    {
                        if (s != null)
                        {
                            if (s.ToLowerInvariant().Equals("content-encoding")) {
                                ce = s;
                            }
                        }
                    }
                    if (ce != null) {
                        rsp.Headers[ce] = "text/html";
                        rsp.Filter = rsp.OutputStream;
                    }
                }
            }
        }
