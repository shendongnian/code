    public class Model
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("urn:test:params:scim:schemas:extension:PersonBioExtension")]
        public TestScimSchemasExtensionBio TestScimSchemasExtensionBio { get; set; }
    }
    public class TestScimSchemasExtensionBio
    {
        [JsonProperty("dateOfBirth")]
        public DateTimeOffset DateOfBirth { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
    }
