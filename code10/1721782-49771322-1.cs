    DateTime datet;
    if(DateTime.TryParseExact(
       DeliveryDateTextBox.Text, 
       "dd-MM-yyyy", 
       CultureInfo.InvariantCulture, 
       DateTimeStyles.None, out datet))
    {
        // string was successfully parsed to dateTime.
    }
