    public DateTime ParseDateInThisYearOrNextYear(string s, out dt) {
        if(!ParseStringToDate(s, "dddd MM dd", out dt) {
            if(!ParseStringToDate(s + " " + DateTime.Now.Year + 1, "dddd MM dd yyyy") {
                throw new FormatException();
            }
        }
    }
    bool ParseStringToDate(string s, string format, out dt) {
        return DateTime.TryParseExact(
            s,
            format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out dt
        );
    }
