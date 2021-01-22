    [MetadataType (typeof (BookingMetadata))]
    public partial class Booking
    {
     // This is your custom partial class     
    }
    
    public class BookingMetadata
    {
     [Required] [StringLength(15)]
     public object ClientName { get; set; }
    
     [Range(1, 20)]
     public object NumberOfGuests { get; set; }
    
     [Required] [DataType(DataType.Date)]
     public object ArrivalDate { get; set; }
    }
    
