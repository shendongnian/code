    var serializer = new XmlSerializer(typeof(Root));
    var obj = (Root)serializer.Deserialize(new StringReader(str));
    var json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
    [XmlRoot(ElementName="file")]
	public class File 
    {
	   [XmlElement(ElementName="field_name")]
	   [JsonProperty(PropertyName = "field_name")]
	   public string Field_name { get; set; }
	   
       [JsonProperty(PropertyName = "field_value")]
	   [XmlElement(ElementName="field_value")]
	   public bool Field_value { get; set; }
	}
	[XmlRoot(ElementName="root")]
	public class Root 
    {
	  [XmlElement(ElementName="file")]
	  [JsonProperty(PropertyName = "file")]
	  public File File { get; set; }
	}
