    string strVal = "12.3";
    double dVal;
    if (double.TryParse(strVal , out dVal))
    {
        // Here, the value of dVal is 12.3
        System.Diagnostics.Debug.WriteLine(dVal);
    }
    else
    {
        // Here, the value of dVal is 0.0
        throw new ArgumentException()
    }
    // Here, we don't know what dVal is. It could be 12.3 or 0.0.
