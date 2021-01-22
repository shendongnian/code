		[XmlElement("")]
		public XmlCDataSection CDataValue {
			get {
				return new XmlDocument().CreateCDataSection(this.Value);
			}
			set {
				this.Value = value.Value;
			}
		}
		
		[XmlText]
		public string Value;
