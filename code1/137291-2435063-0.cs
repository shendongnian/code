    internal sealed partial class TestSettings : ApplicationSettingsBase
    {
        private static TestSettings settings = ((TestSettings)(ApplicationSettingsBase.Synchronized(new TestSettings())));
        public static TestSettings Settings { get { return settings; } }
        [UserScopedSetting()]
        public CameraSettingsClass CameraSettings
        {
            get
            {
                try
                {
                    if(this["CameraSettings"] == null) return (CameraSettingsClass)(new CameraSettingsClass());
                    else return (CameraSettingsClass)this["CameraSettings"];
                }
                catch(Exception error) {throw new Exception("Problem with accessing CameraSettings");}
            }
            set { this["CameraSettings"] = value; }
        }
    }
        public class CameraSettingsClass
        {
            [XmlAttribute]
            public int Width {get;set;}
            [XmlAttribute]
            public int Height {get;set;}
            [XmlAttribute]
            public int Depth {get;set;}
            public CameraSettingsClass()
            {
                this.Width = 1024;
                this.Height = 768;
                this.Depth = 8;
            }
        }
