        public static class GridTypeFactory
        {
            public static IGridType CreateGridType(string screenData)
            {
                switch (screenData)
                {
                    case "Arrival": return new ArrivalDTO();
                    case "Departure": return new DepartureDTO();
                    default: return null;
                }
            }
        }
