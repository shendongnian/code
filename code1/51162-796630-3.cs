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
    
        public static readonly ReallyNice = new HowNice("Really Nice");
        public static readonly KindaNice = new HowNice("Kinda Nice");
        public static readonly NotVeryNice = new HowNice("Really Mean!");
    }
