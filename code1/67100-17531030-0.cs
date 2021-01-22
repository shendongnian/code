                string urlWWW = value.Replace("://", "://www.");
                Uri uriWWW = new Uri(urlWWW);
                foreach (Cookie c in _cookieContainer.GetCookies(uriWWW))
                    if (c.Domain.StartsWith("."))
                        request.Headers["Cookies"] += c.Name + "=" + c.Value + ";"; //manually add the cookies
            }
            //~bug fix
