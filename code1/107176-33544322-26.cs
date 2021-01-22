    public class Widgets : System.Configuration.ConfigurationSection
    {
        public static Widgets Widget => ConfigurationManager.GetSection("widgets") as Widgets;
        [ConfigurationProperty("greetingWidget", IsRequired = true)]
        public GreetingWidgetCollection GreetingWidget
        {
            get { return (GreetingWidgetCollection) this["greetingWidget"]; }
            set { this["greetingWidget"] = value; }
        }
    }
