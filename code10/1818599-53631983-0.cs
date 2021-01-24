     /// Create a new view (profile). 
            /// Documentation https://developers.google.com/analytics/v3/reference/profiles/insert
            /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
            /// </summary>
            /// <param name="service">Authenticated Analytics service.</param>  
            /// <param name="accountId">Account ID to create the view (profile) for.</param>
            /// <param name="webPropertyId">Web property ID to create the view (profile) for.</param>
            /// <param name="body">A valid Analytics v3 body.</param>
            /// <returns>ProfileResponse</returns>
            public static Profile Insert(AnalyticsService service, string accountId, string webPropertyId, Profile body)
            {
                try
                {
                    // Initial validation.
                    if (service == null)
                        throw new ArgumentNullException("service");
                    if (body == null)
                        throw new ArgumentNullException("body");
                    if (accountId == null)
                        throw new ArgumentNullException(accountId);
                    if (webPropertyId == null)
                        throw new ArgumentNullException(webPropertyId);
    
                    // Make the request.
                    return service.Profiles.Insert(body, accountId, webPropertyId).Execute();
                }
                catch (Exception ex)
                {
                    throw new Exception("Request Profiles.Insert failed.", ex);
                }
            }
