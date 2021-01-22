    public DateTime ParseInThisYearOrNextYear(string s, out dt) {
        if(!Parse(s, "dddd MM dd", out dt) {
            if(!Parse(s + " " + DateTime.Now.Year + 1, "dddd MM dd yyyy") {
                throw new FormatException();
            }
        }
    }
    bool Parse(string s, string format, out dt) {
        return DateTime.TryParseExact(
            s,
            format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out dt
        );
    }
