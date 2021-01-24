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
        public virtual int fk_TimeSlotID { get; set; }
        public virtual DateTime? AppointmentDate { get; set; }
    }
    public class AddBookingsViewModelWithAppointment : AddBookingsViewModel
    {
        [Required(ErrorMessage = "Select appointment time ")]
        public override int fk_TimeSlotID {
            get => base.fk_TimeSlotID;
            set => base.fk_TimeSlotID = value;
        }
        [Required(ErrorMessage="Fill in the appointment date")]
        [DataType(DataType.Date)]
        public override DateTime? AppointmentDate {
            get => base.AppointmentDate;
            set => base.AppointmentDate = value;
        }
    }
