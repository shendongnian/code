                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers["X-ApiKey"] = "5AB4374B-A5CF-4F7A-91FF-E5E893347C3F";
                String encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes("myusername" + ":" + "mypassword"));
                httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
