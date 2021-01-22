    public class TiltSettings
    {
        int Theta {get; set;}
        int Rho {get; set;
    }
    public class CameraSettings
    {
        int Width {get; set;}
        int Height {get; set;}
    }
    public class HardwareSettings
    {
        public HardwareSettings(string xml)
        {
            // load your settings here
        }
        CameraSettings Camera {get; set;}
        TiltSettings Tilt {get; set;}
        bool IsInitial {get; set;}
    }
