    namespace MvcApplication1.Models
    {
        [MetadataType(typeof(MovieMetaData))]
        public partial class Movie
        {
        }
    
    
        public class MovieMetaData
        {
            [Required]
            public object Title { get; set; }
