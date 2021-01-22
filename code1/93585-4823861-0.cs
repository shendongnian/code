        /// <summary>
        /// Gets or sets the biz talk catalog.
        /// </summary>
        /// <value>The biz talk catalog.</value>
        private BtsCatalogExplorer BizTalkCatalog { get; set; }
        /// <summary>
        /// Initializes the biz talk artifacts.
        /// </summary>
        private void InitializeBizTalkCatalogExplorer()
        {
            // Connect to the local BizTalk Management database
            BizTalkCatalog = new BtsCatalogExplorer();
            BizTalkCatalog.ConnectionString = "server=BiztalkDbServer;database=BizTalkMgmtDb;integrated security=true";
        }
        /// <summary>
        /// Gets the location from biz talk.
        /// </summary>
        /// <param name="locationName">Name of the location.</param>
        /// <returns></returns>
        private ReceiveLocation GetLocationFromBizTalk(string locationName)
        {
            ReceivePortCollection receivePorts = BizTalkCatalog.ReceivePorts;
            foreach (ReceivePort port in receivePorts)
            {
                foreach (ReceiveLocation location in port.ReceiveLocations)
                {
                    if (location.Name == locationName)
                    {
                        return location;
                    }
                }
            }
            throw new ApplicationException("The following receive location could not be found in the BizTalk Database: " + locationName);
        }
        /// <summary>
        /// Turns the off receive location.
        /// </summary>
        /// <param name="vendorName">Name of the vendor.</param>
        public void TurnOffReceiveLocation(string vendorName)
        {
            ReceiveLocation location = Locations[vendorName].ReceiveLocation;
            location.Enable = false;
            BizTalkCatalog.SaveChanges();
        }
