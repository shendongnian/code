            MultipartFormDataContent o = new MultipartFormDataContent();
            if(options != null)
            {
                foreach (JProperty x in (JToken)options)
                {
                    o.Add(new StringContent((string)x.Value), x.Name);
                }
            }
