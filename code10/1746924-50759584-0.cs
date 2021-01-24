    string incomingData = "00 02 95 97"; // bytes coming from serial port
    string sNosapce = Regex.Replace(incomingData, " ", ""); // remove white spaces from string
               
    string wantedString = sNosapce.Substring(0, 6); // take the first 6 chars
    string finalResult = wantedString.Insert(3, ","); // insert the comma in the wanted index
    Console.WriteLine(finalResult); // here is the final result
               
