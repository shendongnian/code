    interface IConfig 
    {
         string GetConnectionString();
         string GetUserSettings();
         int GetDelay();
    }
    
    class Version_1 : IConfig
    {
         public virtual string GetConnectionString() { ... }
         public virtual string GetUserSettings { ... }
         public virtual int GetDelay();
    }
    
    class Version_1_1 : Version_1
    {
        // Changed UserSetttings and delay in xml
        public override GetUserSettings { ... }
        public override int GetDelay { ... }
    }
    
    class Version_1_1_4
    {
        // Changed delay in xml
        public override int GetDelay { ... }
    }
