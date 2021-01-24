	[System.Xml.Serialization.XmlRootAttribute(IsNullable = false)]
    public class GeneralInformation
    {
        private Info[] addInfoList;
        /// <remarks/>
		[XmlIgnore]
        public Info[] AddInfoList
        {
            get
            {
                return this.addInfoList;
            }
            set
            {
                this.addInfoList = value;
            }
        }
		
		const string InfoPrefix = "Info";
		const string InfoListPrefix = "InfoList";
		
		[XmlAnyElement("InfoList")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public XElement AddInfoListXml
		{
			get
			{
				if (addInfoList == null)
					return null;
				return new XElement(InfoListPrefix,
					addInfoList
					.Select((info, i) => new KeyValuePair<string, Info>(InfoPrefix + (i + 1).ToString("D3", NumberFormatInfo.InvariantInfo), info))
					.SerializeToXElements((XNamespace)""));
			}
			set
			{
				if (value == null)
				{
					addInfoList = null;
				}
				else
				{
					addInfoList = value
						.Elements()
						.Where(e => e.Name.LocalName.StartsWith(InfoPrefix))
						.DeserializeFromXElements<Info>()
						.Select(p => p.Value)
						.ToArray();
				}
			}
		}
    }
