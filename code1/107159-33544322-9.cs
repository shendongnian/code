	public class GreetingElement : ConfigurationElement
	{
		[ConfigurationProperty("greeting", IsRequired = true)]
		public string Greeting
		{
			get { return (string)this["greeting"]; }
			set { this["greeting"] = value; }
		}
	}
