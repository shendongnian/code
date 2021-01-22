        [XmlIgnore]
        public IList<DateTime> Times { get; set; }
        [XmlArray("Times")]
        [XmlArrayItem("Time")]
        public string[] TimesFormatted
        {
            get
            {
                if (this.Times != null)
                    return this.Times.Select((dt) => dt.ToString("MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture)).ToArray();
                else
                    return null;
            }
            set
            {
                if (value == null)
                    this.Times = new List<DateTime>();
                else
                    this.Times = value.Select((s) => DateTime.ParseExact(s, "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture)).ToList();
            }
        }
