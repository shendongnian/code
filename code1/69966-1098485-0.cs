        public void DropSubscription()
        {
            try
            {
                RaiseSyncManagerStatus(string.Format("Dropping subscription '{0}'.", _publicationName));
                Server srv = new Server(_subscriberName);
                MergePullSubscription sub = GetSubscription(srv.ConnectionContext);
                // Remove if it exists
                // Cannot remove from publisher because sysadmin or dbo roles are required
                if (sub.LoadProperties() == true)
                {
                    sub.Remove();
                    RaiseSyncManagerStatus("Subscription dropped.");
                    RaiseSyncManagerStatus("Removing subscription registration from the publisher.");
                    Server srvPub = new Server(_publisherName);
                    MergePublication pub = GetPublication(srvPub.ConnectionContext);
                    // Remove the subscription registration
                    pub.RemovePullSubscription(srv.Name, _subscriberDbName);
                }
                else
                {
                    RaiseSyncManagerStatus("Failed to drop subscription; LoadProperties failed.");
                }
            }
            catch (Exception ex)
            {
                RaiseSyncManagerStatus(ex);
                throw;
            }
        }
        public void DropSubscriberDb()
        {
            try
            {
                RaiseSyncManagerStatus(string.Format("Dropping subscriber database '{0}'.", _subscriberDbName));
                if (SubscriptionValid())
                {
                    throw new Exception("Subscription exists; cannot drop local database.");
                }
                Server srv = new Server(_subscriberName);
                Database db = srv.Databases[_subscriberDbName];
                if (db == null)
                {
                    RaiseSyncManagerStatus("Subscriber database not found.");
                }
                else
                {
                    RaiseSyncManagerStatus(string.Format("Subscriber database state: '{0}'.", db.State));
                    srv.KillDatabase(_subscriberDbName);
                    RaiseSyncManagerStatus("Subscriber database dropped.");
                }
            }
            catch (Exception ex)
            {
                RaiseSyncManagerStatus(ex);
                throw;
            }
        }
