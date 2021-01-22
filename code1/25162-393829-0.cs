public interface IConcept {
    long Code { get; set; }
    [Unique]
    string Name { get; set; }
    bool IsDefault { get; set; }
}
public partial class Concept : IConcept { }
[Table(Name="dbo.Concepts")]
public partial class Concept
{
//...
}
