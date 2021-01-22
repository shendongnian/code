    void Person.SitDown(Seat seat) {
        if (seat.SeatPerson(this)) {
            this.Status = Status.Sitting;
        }
        else
        {
            //Couldn't sit down!
        }
    }
    bool Seat.SeatPerson(Person person) {
        if (this.IsAccepted(person) && this.Seated == null) {
            this.Seated = person;
            return true;
        }
        else
        {
            return false;
        }
    }
