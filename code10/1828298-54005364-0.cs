    double speedOfLight = 299792.458;
    FormattableString message = $"The speed of light is {speedOfLight:N3} km/s.";
    
    System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");
    string messageInCurrentCulture = message.ToString();
    
    var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
    string messageInSpecificCulture = message.ToString(specificCulture);
    
    string messageInInvariantCulture = FormattableString.Invariant(message);
    
    Console.WriteLine($"{System.Globalization.CultureInfo.CurrentCulture,-10} {messageInCurrentCulture}");
    Console.WriteLine($"{specificCulture,-10} {messageInSpecificCulture}");
    Console.WriteLine($"{"Invariant",-10} {messageInInvariantCulture}");
