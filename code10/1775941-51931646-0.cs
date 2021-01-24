                if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
	            {
	                // Connection not available
	                throw new Exception("Not connected.");
	            }
