    public Order(Reservation reservation)  {
        this.date = DateTime.Now;
        this.Reserveration = reservation;
    
        OrderLine orderLine = new OrderLine(reservation);
        //this.attach_Orderlines(orderLine);
        this.Orderlines = new List<OrderLine>();
        this.Orderlines.Add(orderLine);
    }
