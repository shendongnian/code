    //inside Person class
            public bool TrySeat(Seat seat)
            {
                if (seat.TrySeat(this))
                {
                    Status = Sitting;
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
    //inside Seat class
            internal bool TrySeat(Person person)
            {
                if (CanSeat(person))
                {
                    Seated = person;
                    return true;
                }
                else
                {
                    return false;
                }
            }
