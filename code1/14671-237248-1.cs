    public class WidgetPlatform
    {
        public Widget LeftmostWidget { get; set; }
        public Widget RightmostWidget { get; set; }
    
        public WidgetPlatform()
        {
            this.LeftMostWidget = new Widget();
            this.RightMostWidget = new Widget();
        }
    
        public WidgetPlatform(Widget left, Widget right)
        {
            if(left == null || right == null)
                throw new ArgumentNullException("Eeep!");
            
            this.LeftMostWidget = left;
            this.RightMostWidget = right;
        }
    
    
        public String GetWidgetNames()
        {
            return LeftmostWidget.Name + " " + RightmostWidget.Name;
        }
    }
