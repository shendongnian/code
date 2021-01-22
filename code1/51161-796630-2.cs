    class EnumWithToString {
        private String description;
        internal EnumWithToString(String desc){
            description = desc;
        }
        public override ToString(){
            return description;
        }
    }
    class HowNice : EnumWithToString {
        
        private HowNice(String desc) : base(desc){}
    
        public const ReallyNice = new HowNice("Really Nice");
        public const KindaNice = new HowNice("Kinda Nice");
        public const NotVeryNice = new HowNice("Really Mean!");
    }
