    public static ServiceFactory
    {
        public static IDtoService GetService(string dataType)
        {
            switch (dataType)
            {
                case "Arrival":
                    return new ArrivalService();
                case "Departure":
                    return new DepartureDTO();
                default:
                    throw new NonImplementedException("ServiceFactory.GetService cannot create service for " +  dataType);
            }
        }
    }
