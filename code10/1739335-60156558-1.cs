    string[] yourAddresses = new string[2];
    yourAddresses[0] = "delhi/d153";
    yourAddresses[1] = "Taj Mahal";
    List<string> addressList = new List<string>();
    foreach (string line in yourAddresses)
    {
        if (line.Contains("/"))
        {
            addressList.Add("[" + line + "]");
        }
        else
        {
            addressList.Add(line);
        }
    }
       
