    string pattern = string.Join(@"\^\^", 
      "^",              // String start
      "[A-Za-z]+",      // Alphabets
      "[A-Za-z0-9_]+",  // AlphaNumericWithSpecialChracter
      "[A-Za-z0-9]+",   // ANWSC 
      "[A-Za-z0-9]+",   // ANWSC 
      "[0-9]+",         // Numeric
      "[0-9]+",         // Numeric 
      "$");             // End of string
