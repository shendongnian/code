    var numerator = "5"; // let's make it string to prove the point
    double parsedNumerator;
    int denominator = 100; // this could well be a constant
    double result;
    if(Double.TryParse(numerator, out parsedNumerator))
    {
        // notice no casting or convert fluff
        result = parsedNumerator/denominator;
        // do something with the result
    }
    else
    {
        // warn that the numerator is doo-lallie
    }
