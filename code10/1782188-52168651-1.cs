    public class NewService : IService
    {
        public int Calculate(int userId, IConfigurationProvider configurationProvider)
        {
            (int min, _) = configurationProvider.GetSetting(nameof(NewService), "Min", -1);
            (int max, _) = configurationProvider.GetSetting(nameof(NewService), "Max", Int32.MaxValue);
            (string filter, ValueType filterConfigResponse) = configurationProvider.GetSetting(nameof(NewService), "Filter", string.Empty);
            if (filterConfigResponse!=ValueType.ReturnedConfigured)
            {
                throw new ArgumentException("Oh no! Where's my filter?", nameof(configurationProvider));
            }
            Console.WriteLine($"{nameof(NewService)},min={min}, max={max}, filter={filter}");
            return 0;
        }
    }
