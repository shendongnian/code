    DateTime resultDateTime;
    
    var isValid = DateTime.TryParse(string.Format("{0}-{1}-{2}", 2010, 2, 31), out resultDateTime);
    // isValid is false, because 31st of February 2010 does not exist.
    var isValid = DateTime.TryParse(string.Format("{0}-{1}-{2}", 2010, 2, 27), out resultDateTime);
    // isValid is true, and resultDateTime has been set to 27-2-2010.
