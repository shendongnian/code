    class Driver<TVehicle>
        where TVehicle : class, IVehicle, new()
    {
        public TVehicle Vehicle { get; set }
        public Driver()
        {
            Vehicle = new TVehicle();
        }
    }
