        public class DisplayType
    {
    }
    public class Display
    {
        public DisplayType DisplayType {get;set;}
    }
    public class C {
        public Display[] Displays=new Display[0];
        public bool CheckSupport(DisplayType displayType)
        {
             return Displays.Any(x => x.DisplayType == displayType);
        }
    }
