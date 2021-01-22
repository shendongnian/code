    string ToNumericString(int value) {
        return value.ToString("00000000");
    }
    string ToNumericString(decimal value) {
        var value16 = Math.Truncate(value * 100000000);
        return value16.ToString("0000000000000000");
    }
    string ToNumericString(string value) {
        return ToNumericString(int.Parse(value, CultureInfo.InvariantCulture));
    }
