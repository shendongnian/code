    class EnumWithToString {
        private string description;
        internal EnumWithToString(string desc){
            description = desc;
        }
        public override string ToString(){
            return description;
        }
    }
    class HowNice : EnumWithToString {
        
        private HowNice(string desc) : base(desc){}
    
        public static readonly HowNice ReallyNice = new HowNice("Really Nice");
        public static readonly HowNice KindaNice = new HowNice("Kinda Nice");
        public static readonly HowNice NotVeryNice = new HowNice("Really Mean!");
    }
