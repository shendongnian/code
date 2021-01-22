    enum FactoryConfig {
      CONFIG_1 {
         IFactory instantiate() {
            return ...
         }
      },
      CONFIG_2 {
         IFactory instantiate() {
            return ...
         }
      },
      CONFIG_3 {
         IFactory instantiate() {
            return ...
         }
      };
      abstract IFactory instantiate();
    }
    ...
    // and its usage..
   
    IFactory factory = FactoryConfig.CONFIG_3.instantiate();
