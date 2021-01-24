    class MicroserviceStatus {
       public string Name { get; set; }
       public string Status { get; set; }
       public string Description { get; set; }
    }
    
    class MicroserviceHealthCheck {
       public string Status { get; set; }
       public List<MicroserviceStatus> MicroserviceStatuses { get; set; }
    }
    
    var microserviceHealthCheck = JsonConvert.DeserializeObject<MicroserviceHealthCheck>(json);
    
    bool anyNotHealthy = microserviceHealthCheck.MicroserviceStatuses.Any(i => i.Status != "Healthy");
