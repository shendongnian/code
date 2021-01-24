	public class StringArray
	{
		[XmlIgnore]
		public List<Day> Days { get; set; }
		[XmlElement("Days")]
		public DayListDTO XmlDaysSurrogate { get { return Days; } set { Days = value; } }
	}
