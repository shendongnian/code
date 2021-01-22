cs
[XmlIgnore]
public string Content { get; set; }
[XmlText]
public XmlNode[] ContentAsCData
{
	get => new[] { new XmlDocument().CreateCDataSection(Content) };
	set => Content = value?.Cast<XmlCDataSection>()?.Single()?.Data;
}
