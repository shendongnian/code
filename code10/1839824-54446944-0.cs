    public class ProcessProofs
    {
        public void Process()
        {
            var context = new RestaurantVersion();
            List<DbRestaurantVersion> restaurantVersions = context.RestaurantVersions.ToList();
            foreach (DbRestaurantVersion item in restaurantVersions)
            {
                //process item
            }
        }
    }
