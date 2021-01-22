    public class BookingValidationService : IBookingValidationService
    {
        public IRoomTypeService RoomTypeService { get; set; }
    
        public IBookingValidator BookingValidator { get; set; }
    
        public ValidationResult ValidateBooking(Booking booking, string tourCode)
        {
            BookingValidator.AvailableRooms = RoomTypeService.GetAvailableRoomTypesForTour(tourCode);
        
            return BookingValidator.Validate(booking);
        }
    }
