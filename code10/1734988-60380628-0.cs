     public static void Injection(IServiceCollection services)
     
     {
     
      var jsonServices = JObject.Parse(File.ReadAllText("dependency.json"))["services"];
     
      var requiredServices = JsonConvert.DeserializeObject < List < Service >> (jsonServices.ToString());
     
      foreach(var service in requiredServices)
     
      {
     
       var serviceType = Type.GetType(service.ServiceType.Trim() + ", " + service.Assembly.Trim());
     
       var implementationType = Type.GetType(service.ImplementationType.Trim() + ", " + service.Assembly.Trim());
     
       var serviceLifetime = (ServiceLifetime) Enum.Parse(typeof(ServiceLifetime), service.Lifetime.Trim());
     
       var serviceDescriptor = new ServiceDescriptor(serviceType: serviceType,
     
        implementationType: implementationType,
     
        lifetime: serviceLifetime);
     
       services.Add(serviceDescriptor);
     
      }
