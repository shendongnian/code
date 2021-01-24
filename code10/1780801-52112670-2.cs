    public void UpdateBooking(Booking updatingBooking)
    {
        **INIT UNIT OF WORK**
        Booking bookingInDb=unitOfWork.BookingRepository.Find(updatingBooking.Id); 
        //updatingBooking.Id might be null, you need to pass the Id of the row you want to update
        bookingInDb.BookingStart=updatingBooking.BookingStart;
        //We update only BookingStart but not BookingEnd or Car_Id
        unitOfWork.BookingRepository.Update(bookingInDb);
        unitOfWork.Save();
    }
