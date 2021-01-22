    public class GreetingWidgetCollection : ConfigurationElementCollection
   	{
   		public List<IGreeting> All { get { return this.Cast<IGreeting>().ToList(); } }
   
   		public GreetingElement this[int index]
   		{
   			get
   			{
   				return base.BaseGet(index) as GreetingElement;
   			}
   			set
   			{
   				if (base.BaseGet(index) != null)
   				{
   					base.BaseRemoveAt(index);
   				}
   				this.BaseAdd(index, value);
   			}
   		}
   
   		protected override ConfigurationElement CreateNewElement()
   		{
   			return new GreetingElement();
   		}
   
   		protected override object GetElementKey(ConfigurationElement element)
   		{
   			return ((GreetingElement)element).Greeting;
   		}
   	}
