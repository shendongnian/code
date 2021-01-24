    class BananaFactory {
    
        public int price;
        public string origins;
    
        Banana CreateBanana() {
            return new Banana(){
                peelDensity = "SomeValue",
                price = price,
                origins = origins
            };
        }
    }
    
    
    var banana = bananaFactoryinstance.CreateBanana();
    
    // banana has price and origins that are set in the factory 
