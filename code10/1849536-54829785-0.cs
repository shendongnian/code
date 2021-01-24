`C#
public class Example 
{
    public string id { get; set; }
    public int number { get; set; }
    public string configured_perspective { get; set; }
    private Perspective _configuredPespective;
    [JsonIgnore]
    public Perspective ConfiguredPerspective => _configuredPerspective == null ? new Perspective(configured_persective) : _configuredPerspective;
}
`
It's not perfect, and we hold onto the string wasting memory, but it might work for you as a work-around.
