    public class Group
    {
        public string Value{ get; set; }
        public Group( string value ){ Value = value; } 
        public static Group TheGroup() { return new Group("OEM"); }
        public static Group OtherGroup() { return new Group("CMB"); }
        
    }
