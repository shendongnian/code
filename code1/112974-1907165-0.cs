    [XmlIgnore]
    public Bitmap LargeIcon { get; set; }
    [Browsable(false),EditorBrowsable(EditorBrowsableState.Never)]
    [XmlElement("LargeIcon")]
    public byte[] LargeIconSerialized
    {
        get { // serialize
            if (LargeIcon == null) return null;
            using (MemoryStream ms = new MemoryStream()) {
                LargeIcon.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }
        set { // deserialize
            if (value == null) {
                LargeIcon = null;
            } else {
                using (MemoryStream ms = new MemoryStream(value)) {
                    LargeIcon = new Bitmap(ms);
                }
            }
        }
    }
