    public class Control // (could be base class or whatever is needed)
    {
    
    }
    
    public class ImageControl extends Control
    {
    
    }
    
    public class ControlFactory
    {
        public static Control createControl(String control)
        {
            if(control == "IMAGE")
            {
                return new ImageControl();
            }
            // error situation, control was unknown.
        } 
    }
