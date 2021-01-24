     [HttpGet]
     public AcquireKeysRequest Get()
     {
         AcquireKeysRequest req = new AcquireKeysRequest();
         req.KeyTiming = new KeyTiming() { Position = 2 };
         req.Protection = new Protection()
         {
             ProtectionSystem = new ProtecionSystem() {
                  SystemId = "wkow", Type = "type"
             }
         };
         req.Version = 2;
         req.Content = new Content() { Id = "id", Type = "type" };
         return req;
     }
     [HttpPost]
     public void Post([FromBody]AcquireKeysRequest value)
     {
     }
