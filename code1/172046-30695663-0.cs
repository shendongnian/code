     public static bool IsValidUrl(string url)
	        {
	            if (string.IsNullOrEmpty(url)) { return false;}
	
	            if (!url.StartsWith("http://"))
	            {
	                url = "http://" + url;    
	            }
	
	            Uri outWebsite;
	
	            return Uri.TryCreate(url, UriKind.Absolute, out outWebsite) && outWebsite.Host.Replace("www.", "").Split('.').Count() > 1 && outWebsite.HostNameType == UriHostNameType.Dns && outWebsite.Host.Length > outWebsite.Host.LastIndexOf(".") + 1 && 255 >= url.Length;
	        }
