    public class Camera
    {
        public BackgroundColorValue backgroundColorValue { get; set; } 
            = new BackgroundColorValue();
        public BackgroundColorRef backgroundColorRef { get; set; } 
            = new BackgroundColorRef();
    }
    public struct BackgroundColorValue
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
    }
    public class BackgroundColorRef
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
    }
    var shortCutValue = cammera.backgroundColorValue;
    var shortCutRef = cammera.backgroundColorRef;
    shortCutValue.r = 5;
    shortCutRef.r = 10;
 
    //cammera.backgroundColorValue.r == 0, shortCutValue == 5
    //cammera.backgroundColorRef.r == 10, shortCutValue == 10
    
