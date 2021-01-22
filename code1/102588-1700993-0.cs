    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public string FirstName { get; set; }
        ....
        ....
    }
    public class UserMetaData
    {
        [Required]
        [RegularExpression("[a-zA-Z]{2,30}")]
        public string FirstName { get; set; }
        ....
        ....
