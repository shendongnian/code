	public class root 
	{
		[XmlArray("largeImages")]
		[XmlArrayItem("largeImage")]
		public List<image> Images { get; set; } = new List<image>();
	
		[XmlArray("smallImages")]
		[XmlArrayItem("smallImage")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public List<image> SmallImagesSurrogate { get { return Images; } }
		
		public bool ShouldSerializeSmallImagesSurrogate() { return false; }
	}
