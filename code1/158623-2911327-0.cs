    DateTime date;
    bool valid;
    valid = DateTime.TryParseExact("00/00", "dd/MM", null, DateTimeStyles.None, out date); // false
    valid = DateTime.TryParseExact("30/02", "dd/MM", null, DateTimeStyles.None, out date); // false
    valid = DateTime.TryParseExact("27/02", "dd/MM", null, DateTimeStyles.None, out date); // true
