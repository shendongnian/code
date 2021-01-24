        public IEnumerable<simPayRate> GetPayRate
        {
            get
            {
                return context.simPayRates.Include("simHoursType");
            }
        }
