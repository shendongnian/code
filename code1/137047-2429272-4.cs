    public class Filter
    {
        private UserCollection users;
        private GeoRegionCollection regions;
        public void Process(UserCollection users, GeoRegionCollection regions)
        {
            this.users = users;;
            this.regions = regions;
        }
        public void Process()
        {
            foreach (User u in users)
            {
                foreach (GeoRegion r in regions)
                {
                    Process(u, r, ##);
                }
            }
        }
    
        public void Process(User u, GeoRegion r, int countNeeded)
        {
            // as before
        }
    }
