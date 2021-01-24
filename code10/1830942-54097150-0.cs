    public class Tbl_Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long fld_organization_id { get; set; }
        public byte? fld_organization_type_id_ref { get; set; }  // This FK needs to match referenced PK type fld_location_id_ref
        // Are you missing or not showing 
        [StringLength(500)]
        public string fld_organization_name { get; set; }
    
        [StringLength(200)]
        public string fld_organization_address { get; set; }
    
        [ForeignKey("fld_location_id_ref")]
        public Tbl_Personnel_Location Tbl_Personnel_Location { get; set; }
    
        [ForeignKey("fld_organization_type_id_ref")]
        public Tbl_Organization_Type Tbl_Organization_Type { get; set; }
    }
