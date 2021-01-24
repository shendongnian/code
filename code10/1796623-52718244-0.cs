     public static class McfSample
        {
    
            public class McfGetOptionalParms
            {
                /// A comma-separated list of Multi-Channel Funnels dimensions. E.g., 'mcf:source,mcf:medium'.
                public string Dimensions { get; set; }  
                /// A comma-separated list of dimension or metric filters to be applied to the Analytics data.
                public string Filters { get; set; }  
                /// The maximum number of entries to include in this feed.
                public int? Max-results { get; set; }  
                /// The desired sampling level.
                public string SamplingLevel { get; set; }  
                /// A comma-separated list of dimensions or metrics that determine the sort order for the Analytics data.
                public string Sort { get; set; }  
                /// An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.
                public int? Start-index { get; set; }  
            
            }
     
            /// <summary>
            /// Returns Analytics Multi-Channel Funnels data for a view (profile). 
            /// Documentation https://developers.google.com/analytics/v3/reference/mcf/get
            /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
            /// </summary>
            /// <param name="service">Authenticated Analytics service.</param>  
            /// <param name="ids">Unique table ID for retrieving Analytics data. Table ID is of the form ga:XXXX, where XXXX is the Analytics view (profile) ID.</param>
            /// <param name="start-date">Start date for fetching Analytics data. Requests can specify a start date formatted as YYYY-MM-DD, or as a relative date (e.g., today, yesterday, or 7daysAgo). The default value is 7daysAgo.</param>
            /// <param name="end-date">End date for fetching Analytics data. Requests can specify a start date formatted as YYYY-MM-DD, or as a relative date (e.g., today, yesterday, or 7daysAgo). The default value is 7daysAgo.</param>
            /// <param name="metrics">A comma-separated list of Multi-Channel Funnels metrics. E.g., 'mcf:totalConversions,mcf:totalConversionValue'. At least one metric must be specified.</param>
            /// <param name="optional">Optional paramaters.</param>
            /// <returns>McfDataResponse</returns>
            public static McfData Get(AnalyticsService service, string ids, string start-date, string end-date, string metrics, McfGetOptionalParms optional = null)
            {
                try
                {
                    // Initial validation.
                    if (service == null)
                        throw new ArgumentNullException("service");
                    if (ids == null)
                        throw new ArgumentNullException(ids);
                    if (start-date == null)
                        throw new ArgumentNullException(start-date);
                    if (end-date == null)
                        throw new ArgumentNullException(end-date);
                    if (metrics == null)
                        throw new ArgumentNullException(metrics);
    
                    // Building the initial request.
                    var request = service.Mcf.Get(ids, start-date, end-date, metrics);
    
                    // Applying optional parameters to the request.                
                    request = (McfResource.GetRequest)SampleHelpers.ApplyOptionalParms(request, optional);
    
                    // Requesting data.
                    return request.Execute();
                }
                catch (Exception ex)
                {
                    throw new Exception("Request Mcf.Get failed.", ex);
                }
            }
            
            }
    
            public static class SampleHelpers
            {
    
            /// <summary>
            /// Using reflection to apply optional parameters to the request.  
            /// 
            /// If the optonal parameters are null then we will just return the request as is.
            /// </summary>
            /// <param name="request">The request. </param>
            /// <param name="optional">The optional parameters. </param>
            /// <returns></returns>
            public static object ApplyOptionalParms(object request, object optional)
            {
                if (optional == null)
                    return request;
    
                System.Reflection.PropertyInfo[] optionalProperties = (optional.GetType()).GetProperties();
    
                foreach (System.Reflection.PropertyInfo property in optionalProperties)
                {
                    // Copy value from optional parms to the request.  They should have the same names and datatypes.
                    System.Reflection.PropertyInfo piShared = (request.GetType()).GetProperty(property.Name);
    				if (property.GetValue(optional, null) != null) // TODO Test that we do not add values for items that are null
    					piShared.SetValue(request, property.GetValue(optional, null), null);
                }
    
                return request;
            }
        }
    }
