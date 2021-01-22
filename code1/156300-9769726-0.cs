        [XmlIgnore]
        public DateTime? AllocationDate
        {
            get { return _allocationDate; }
            set { _allocationDate = value; }
        }
        [XmlAttribute("AllocationDateTime")]
        public string AllocationDateTimeString
        {
            get
            {
                return _allocationDate.HasValue ? XmlConvert.ToString(_allocationDate.Value, XmlDateTimeSerializationMode.Unspecified)
                : string.Empty;
            }
            set
            {
                _allocationDate = !string.IsNullOrEmpty(value) ? XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Unspecified) : (DateTime?)null;
            }
        }
