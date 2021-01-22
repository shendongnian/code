    public static class Default
    {
        private const int DefaultSrid = 4326;
        public static readonly IGeometryFactory Factory;
        static Default()
        {
            Factory = new GeometryFactory(new PrecisionModel(), DefaultSrid);
        }
    }
