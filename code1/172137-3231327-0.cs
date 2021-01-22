    // The number of elements in headersSplit will be the number of ':' characters
    // in line + 1.
    string[] headersSplit = line.Split(':');
    string hname = headersSplit[0];
    
    // If you are getting an IndexOutOfRangeException here, it is because your
    // headersSplit array has only one element. This tells me that line does not
    // contain a ':' character.
    string hvalue = headersSplit[1];
