        [Serializable]
		public class Foo
		{
			[XmlIgnore]
			public bool? Bar { get; set; }
			[XmlAttribute("Bar")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public string xmlBar
			{
				get { return Bar.ToString(); }
				set
				{
					if (string.IsNullOrEmpty(value)) Bar = null;
					else Bar = bool.Parse(value);
				}
			}
		}
