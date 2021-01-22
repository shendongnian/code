    double number;
    string localStringNumber;
    string doubleNumericValueasString = "65.89875";
    System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
    if (double.TryParse(doubleNumericValueasString, style, System.Globalization.CultureInfo.InvariantCulture, out number))
        Console.WriteLine("Converted '{0}' to {1}.", doubleNumericValueasString, number);
    else
        Console.WriteLine("Unable to convert '{0}'.", doubleNumericValueasString);
    localStringNumber =number.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("de-DE"));
