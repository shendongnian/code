        catch (WebException e)
        {
            using (WebResponse response = e.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Returned Status Code: {httpResponse.StatusCode.ToString()}");
                using (Stream data = httpResponse.GetResponseStream())
                {
                    for (var i = 0; i < httpResponse.Headers.Count; ++i)
                    {
                        stringBuilder.AppendLine($"{httpResponse.Headers.Keys[i]}: {httpResponse.Headers[i]}");
                    }
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        stringBuilder.AppendLine($"Body: {text}");
                    }
                }
                // do whatever
            }
        }
