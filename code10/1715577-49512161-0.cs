    public SeatStatus SeatStatus[int col]
    {
      get
       {
          switch(col)
            case 1: return SeatCol1Status;
            case 2: return SeatCol2Status;
            // etc    
       }
    }
