    [MetadataType(typeof(Person.Metadata))]
    public partial class Person {
        private sealed class MetaData {
            [RegularExpression(...)]
            public string Email { get; set; }
        }
    }
