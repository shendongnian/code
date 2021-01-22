    string s;
    double epislon = 0.0000001; // or however near zero you want to consider as zero
    if (Math.Abs(value) < epislon) {
        int digits = Math.Log10( Math.Abs( value ));
        // if (digits >= 0) ++digits; // if you care about the exact number
        if (digits < -5) {
           s = string.Format( "{0:0.000000000}", value );
        }
        else if (digits < 0) {
           s = string.Format( "{0:0.00000})", value );
        }
        else {
           s = string.Format( "{0:#,###,##0.000}", value );
        }
    }
    else {
        s = "0";
    }
