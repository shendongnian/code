    DateTime arrivalDate = DateTime.Parse(firstDate);
    DateTime departureDate = DateTime.Parse(secondDate);
    DateTime summerStart = DateTime.Parse("15-06-2018");
    DateTime summerEnd = DateTime.Parse("15-08-2018");
    if (arrivalDate >= summerStart && departureDate <= summerEnd)
    {
        flightPrice = 238 * 1.20 * people;
    }
    else
    {
            flightPrice = 238 * people;
    }
