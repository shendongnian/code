    class VehicleRepository
    {
        private readonly IAutoDbSets context;
        public VehicleRepository(IAutoDbSets context)
        {
            this.context = context;
        }
    }
