    // 2 / 3 = 0 with a remainder of 2; remainder is discarded
    double result = 2 / 3;
    // 2.0 / 3.0 = 0.6667, as expected
    double result = Convert.ToDouble(2) / Convert.ToDouble(3);
    // double.Parse takes a string parameter, so this gives a syntax error
    double result = double.Parse(2) / double.Parse(3);
    // As above, double.Parse takes a string, so syntax error
    // This also does integer arithmetic inside the parentheses, so you would still
    // have zero as the result anyway.
    double result = double.Parse(2 / 3); // gives me errors
    // Here, the integer division 2 / 3 is calculated to be 0 (throw away the
    // remainder), and *then* converted to a double, so you still get zero.
    double result = Convert.ToDouble(2 / 3);
