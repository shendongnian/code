    //-----------------------------------------------------------------------
    
    #region Spares Section
    
    [MetadataType(typeof(SparesSectionMetaData))]
    public partial class SparesSection { }
    
    public class SparesSectionMetaData
    {
        [ScaffoldColumn(false)]
        [DefaultValue(0)]
        [Required]
        public int SparesSectionId { get; set; }
    
        [DisplayName("Spares Section Title")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2-100 characters")]
        [Required]
        public string SparesSectionTitle { get; set; }
    }
