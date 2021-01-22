    public interface IGreeting
    {
        string Greeting { get; set; }
    }
	public class GreetingElement : System.Configuration.ConfigurationElement, IGreeting
	{
		[ConfigurationProperty("greeting", IsRequired = true)]
		public string Greeting
		{
			get { return (string)this["greeting"]; }
			set { this["greeting"] = value; }
		}
	}
