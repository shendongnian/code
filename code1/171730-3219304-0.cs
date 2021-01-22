    public class MySettings
    {
        private static MySettings _instance;
        public static MySettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MySettings();
                    // maby call Load();
                }
                return _instance;
            }
        }
        private MySettings()
        {  
            //set default values
        }
        public void Load()
        {
            Stream stream = File.Open("settings_test.xml", FileMode.Open);
            XmlSerializer x = new XmlSerializer(this.GetType());
            _instance = (MySettings)x.Deserialize(stream);
        }
        public void Save()
        { 
            Stream stream = File.Open("settings_test.xml", FileMode.Create);
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(stream, _instance);
        }
    }
   
