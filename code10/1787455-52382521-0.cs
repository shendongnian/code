    public class FieldViewModel
    {
       [JsonProperty(PropertyName="field")]
       public Field Field { get; set; }
       
       [JsonProperty(PropertyName="chartData")]
       public object[] ChartData { get; set; }
       [JsonProperty(PropertyName="asparaguses")]
       public Asparagus[] Asparaguses { get; set; }
    }
