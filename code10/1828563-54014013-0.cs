	using (var proxy = new WindowsService1.ServiceReference1.InventoryServiceClient())
	{
		var response = proxy.GetModifiedBookings(getModBkgsReq);
		if (response.Bookings == null)
		{
			this.WriteToFile("ERROR: Booking details not returned from GetModifiedBookings! " +StartDate);
			return;
		}
		var booking = response.Bookings.SingleOrDefault( b => b.BookingId == bookingCode);
		if (booking == null)
		{
			this.WriteToFile("Sorry could not find your source of booking");
			return;
		}
		var bookingSource = booking.BookingSource;
		this.WriteToFile("Booking Source =" + bookingSource + "");
	}
	
