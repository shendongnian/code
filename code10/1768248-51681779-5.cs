    public class DayListDTO
    {
        [XmlIgnore]
		public Day [] Days { get; set; }
		
        [XmlChoiceIdentifier("Days")]
        [XmlElement(nameof(Day.Monday), typeof(object))]
        [XmlElement(nameof(Day.Tuesday), typeof(object))]
        [XmlElement(nameof(Day.Wednesday), typeof(object))]
        [XmlElement(nameof(Day.Thursday), typeof(object))]
        [XmlElement(nameof(Day.Friday), typeof(object))]
        [XmlElement(nameof(Day.Saturday), typeof(object))]
        [XmlElement(nameof(Day.Sunday), typeof(object))]
		public object[] DaysObjects
        {
            get
            {
                return Days == null ? null : Enumerable.Repeat(new object(), Days.Length).ToArray();
            }
            set
            {
                // Do nothing
            }
        }
		public static implicit operator DayListDTO(List<Day> list)
		{
			return list == null ? null : new DayListDTO { Days = list.ToArray() };
		}
		
		public static implicit operator List<Day>(DayListDTO dayList)
		{
			return dayList?.Days?.ToList() ?? new List<Day>();
		}
    }
