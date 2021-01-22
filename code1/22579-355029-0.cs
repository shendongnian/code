    string s;
    if (value != 0) {
        int digits = Math.Log10( Math.Abs( value )); // truncate to get digits
        if (digits < -5) {
           s = string.Format( "{0:0.0000000000}", value );
        }
        else if (digits < 0) {
           s = string.Format( "{0:0.00000})", value );
        }
        else ...
    }
    else {
        s = "0";
    }
