    using (System.Net.HttpWebResponse resp = (System.Net.HttpWebResponse)req.GetResponse())
        {
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                using (var stream = resp.GetResponseStream())
                {
                    // Process data with JSON.NET library here
                }
            }
        }
