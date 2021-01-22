     public static bool CheckUrlValid(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            if(result)
            {
                uriResult = new Uri(url);
                if (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp)
                    return true;
            }
            return false;
        }
