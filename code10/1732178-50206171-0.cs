    public class BallUtilities
    {
        enum BallColors { Red, Blue, Green, Yellow, Pink, Purple ... };
        public static Color32 ToColor(this BallColor ballColor) =>
        {
             switch (ballColor)
             {
                 case BallColor.Red:  return new Color32 (255, 50, 50);
                 case BallColor.Blue: return new Color32 (50,  50, 255);
                 case BallColor.Green: ...
                 .
                 .
                 .
                 (etc.)
             }
        }
    }
