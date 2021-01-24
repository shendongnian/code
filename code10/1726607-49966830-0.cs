    public void insertBooking(int bookingID, int customerID, int entertainmentID,
                              DateTime bookingDate, int numberOfGuests, double price,
                              bool deposit, decimal depositPrice)
    {
        using (var con = new SqlConnection(yourConnectionString))
        using (var cmd = con.CreateCommand())
        {
            cmd.CommandText = @"INSERT INTO Booking (bookingID, customerID, entertainmentID, 
                                [Booking Date], [Number Of Guests], [Price], [Deposit?], 
                                [Deposit Price]) Values(@bookId, @cusId, @entId, @bookdate, @guests, @price, @deposit, @depositPrice)";
            cmd.Parameters.Add("@bookId", SqlDbType.Int).Value = bookingID;
            cmd.Parameters.Add("@cusId", SqlDbType.Int).Value = customerID;
            cmd.Parameters.Add("@entId", SqlDbType.Int).Value = entertainmentID;
            cmd.Parameters.Add("@bookdate", SqlDbType.DateTime).Value = bookingDate;
            cmd.Parameters.Add("@guests", SqlDbType.Int).Value = numberOfGuests;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
            cmd.Parameters.Add("@deposit", SqlDbType.Bit).Value = deposit;
            cmd.Parameters.Add("@depositPrice", SqlDbType.Decimal).Value = depositPrice;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
