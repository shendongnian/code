    using System;
    using System.Text.RegularExpressions;
    int result =
        // The Convert (System) class comes in pretty handy everytime
        // you want to convert something.
        Convert.ToInt32(
            Regex.Replace(
                "12ACD", // Our input
                "[^0-9]", // Select everything that is not in
                          // the range of 0-9
                String.Empty // Replace that with an empty string.
        ));
