    public class MyProperties : ConfigurationSection {
        [ConfigurationProperty("A")]
        public MySettings A
        {
            get { return (MySettings )this["A"]; }
            set { this["A"] = value; }
        }
        [ConfigurationProperty("B")]
        public MySettings B
        {
            get { return (MySettings )this["B"]; }
            set { this["B"] = value; }
        }
    }
    public class MySettings : ConfigurationElement {
        [ConfigurationProperty("greeting")]
        public string Greeting
        {
            get { return (string )this["greeting"]; }
            set { this["greeting"] = value; }
        }
    }
