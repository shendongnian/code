    public IEnumerable<Server> GetServers() {
        // initialze to null
        ServersDataContext sdc = null;
        try {
            // get connected
            using (sdc = GetDataContext()) {
                // disable this deferred loading
                sdc.DeferredLoadingEnabled = false;
                foreach (var relation in from svr in sdc.Servers) // complex linq here
                    yield return relations;
            }
        }
        catch (Exception ex) {
            LogError(ex, "fwizs.Internal");
            throw;
        }
        finally {
            if (sdc != null) {
                sdc.Dispose();
            }
        }
    }
