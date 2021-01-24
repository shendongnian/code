    namespace Services
    {
        public interface IStationService
        {
            Task CreateAsync(Models.Station model);
            Task UpdateAsync(Models.Station oldModel, Models.Station newModel);
        }
    }
