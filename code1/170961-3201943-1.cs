    /* CheckableFacility has to be a viewmodel to serve the 
       ListViewItem in the UserControlHotelDescription (and other views) */
    public class CheckableFacilityViewModel
    { 
        public int Id { get; set; }  /* I'm not sure if you use Id in your View */
        public FacilityCategory ReporterFacilityCategory { get; set; }  
        public bool IsChecked { get; set; } 
        public string Name { get; set; }  
    } 
    
