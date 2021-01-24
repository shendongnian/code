    public int Compare(Status x, Status y) {
      if (IsUnpaid(x)) { 
        if (!IsUnpaid(y))
          return IsAscending ? -1 : 1; // x is unPaid, y is Paid
      }
      else if (IsUnpaid(y)) { 
        return IsAscending ? 1 : -1;   // x is Paid, y is unPaid
      }
      // x and y either both Paid or unPaid
      return x.CompareTo(y);
    }
