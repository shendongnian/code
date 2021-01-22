    public class Stuff
    {
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string MultiLineProperty { get; set; }
    }
