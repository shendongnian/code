    class HowNice {
        
        private String description;
        private HowNice(String desc){
            description = desc;
        }
        
        public override ToString(){
            return description;
        }
    
        public const ReallyNice = new HowNice("Really Nice");
        public const KindaNice = new HowNice("Kinda Nice");
        public const NotVeryNice = new HowNice("Really Mean!");
  
    }
