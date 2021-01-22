    [MetadataType(typeof(MyModelMetadata))]
    public partial class OriginalMyModel
    {
    }
    
    public class MyModelMetadata
    {
        [Required]
        public string MyProperty;  
        // ...
    }
