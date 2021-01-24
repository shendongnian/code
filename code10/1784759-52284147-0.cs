                HttpWebRequest request = WebRequest.Create("https://api.ebay.com/sell/compliance/v1/listing_violation?compliance_type=PRODUCT_ADOPTION")   
            as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, System.Web.HttpUtility.HtmlEncode("Bearer " + accessToken));
            request.Headers.Add("X-EBAY-C-MARKETPLACE-ID", "EBAY-US");
            log.Debug("starting request.GetRequestStream");
            string result = null;
            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
