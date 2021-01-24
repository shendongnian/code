    DateTime datet;
    if(DateTime.TryParseExact(
       DeliveryDateTextBox.Text, 
       "dd-MM-yyyy", 
       CultureInfo.InvariantCulure, 
       DateTimeStyles.None))
    {
        // parsed succesfully...
    }
