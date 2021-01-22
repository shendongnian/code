		public abstract class IHaveSomething
		{
			public abstract string Something { get; set; }
		}
		public class MySomething : IHaveSomething
		{
			string _sometext;
			public override string Something 
			{ get { return _sometext; } set { _sometext = value; } }
		}
		[XmlRoot("abc")]
		public class seriaized
		{
			[XmlElement("item", typeof(MySomething))]
			public IHaveSomething data;
		}
