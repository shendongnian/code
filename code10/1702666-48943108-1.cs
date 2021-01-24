    public static ListConnectionsResponse List(PeopleserviceService service, string resourceName, ConnectionsListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (resourceName == null)
                    throw new ArgumentNullException(resourceName);
                // Building the initial request.
                var request = service.Connections.List(resourceName);
                // Applying optional parameters to the request.                
                request = (ConnectionsResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);
                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Connections.List failed.", ex);
            }
        }
        
        }
