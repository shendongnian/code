    public class ServiceA : IServiceB {
        private readonly MySetting setting;
    
        public ServiceA(MySetting setting) {
            this.setting = setting;
        }
    
        public string someVariable => setting.WantedKey;
        //...
    }
