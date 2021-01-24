    public int Compare(Status x, Status y) {
      if (IsUnpaid(x)) { 
        if (!IsUnpaid(y))
          return IsAscending ? -1 : 1; // x is UnPaid, y is Paid
      }
      else if (IsUnpaid(y)) { 
        return IsAscending ? 1 : -1;   // x is Paid, y is UnPaid
      }
      // x and y either both Paid or unPaid
      return x.CompareTo(y);
    }
