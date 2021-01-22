    public static void ResponseRedirect(HttpResponse iResponse, string iUrl)
        {
            ResponseRedirect(iResponse, iUrl, HttpContext.Current);
        }
    
        public static void ResponseRedirect(HttpResponse iResponse, string iUrl, HttpContext iContext)
        {
            iResponse.Redirect(iUrl, false);
    
            iContext.ApplicationInstance.CompleteRequest();
    
            iResponse.BufferOutput = true;
            iResponse.Flush();
            iResponse.Close();
        }
