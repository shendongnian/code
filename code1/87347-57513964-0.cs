cs
[XmlIgnore]
public string Content { get; set; }
[XmlText]
public XmlNode[] ValueAsCData
{
	get => new[] { new XmlDocument().CreateCDataSection(Content) };
	set => Content = value?.Cast<XmlCDataSection>()?.Single()?.Data;
}
