    public class AddBookingsViewModel
    {
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public string VehicleRegNo { get; set; }
        public short fk_VehicleMakeID { get; set; }
        public string VehicleModel { get; set; }
        public byte fk_BookingModeID { get; set; }
        public int EntryUserID { get; set; }
        public int ReturnBookingID { get; set; }    
    }
    public class AddBookingsViewModelWithAppointment : AddBookingsViewModel
    {
        [Required(ErrorMessage = "Select appointment time ")]
        public int fk_TimeSlotID { get; set; }
        [Required(ErrorMessage="Fill in the appointment date")]
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }
    }
