    class FlightManager
    {
        private object _lock = new object();
        private List<FlightInfo> _flights = new List<FlightInfo>();
        public void Add(FlightInfo info)
        {
            lock(_lock)
            {
                // look for existing flights
                var existing = _flights.FirstOrDefault(f =>
                {
                    return f.FlightNumber == info.FlightNumber
                        && f.TakeoffTime == info.TakeoffTime;
                });
                // FirstOrDefault will return null if none found
                if(existing == null)
                {
                    // add as new flight
                    _flights.Add(info);
                }
                else
                {
                    // add passenger count
                    existing.UserCount += info.UserCount;
                }
            }
        }
    }
