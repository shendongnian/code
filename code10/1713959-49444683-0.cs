            var cookies = CookieManager.GetEnumerator();
            while (cookies.MoveNext())
            {
                if (cookies.Current.Name == "CookieIHate")
                {
                    CookieManager.Remove(cookies.Current.Host, cookies.Current.Name, cookies.Current.Path, false);
                }
            }
