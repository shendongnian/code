    public class TiltSettings
    {
        public TiltSettings(XElement element)
        {
            this.Theta = Convert.ToInt32(element.Attribute("theta").Value);
            this.Rho = Convert.ToInt32(element.Attribute("rho").Value);
        }
        public int Theta {get; set;}
        public int Rho { get; set; }
    }
    public class CameraSettings
    {
        public CameraSettings(XElement element)
        {
            this.Height = Convert.ToInt32(element.Attribute("height").Value);
            this.Width = Convert.ToInt32(element.Attribute("width").Value);
            this.Depth = Convert.ToInt32(element.Attribute("depth").Value);
        }
        public int Width {get; set;}
        public int Height {get; set;}
        public int Depth { get; set; }
    }
    public class HardwareSettings
    {
        public HardwareSettings(string xml)
        {
            var xDoc = XDocument.Parse(xml);
            this.IsInitial = xDoc.Root.Attribute("initial").Value == "true";
            this.Camera = new CameraSettings(xDoc.Root.Element("cameraSettings"));
            this.Tilt = new TiltSettings(xDoc.Root.Element("tiltSettings"));
        }
        public CameraSettings Camera {get; set;}
        public TiltSettings Tilt {get; set;}
        public bool IsInitial {get; set;}
    }
