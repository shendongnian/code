    public class DataCollector
    {
        public void CollectData()
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.GetInterfaces().Any(x => x.IsGenericType 
                            && x.GetGenericTypeDefinition() == typeof(IDataRecievable<>)));
            foreach (var type in typesToRegister)
            {
                dynamic sensor = Activator.CreateInstance(type);
                sensor.CollectData();
            }
        }
    }
