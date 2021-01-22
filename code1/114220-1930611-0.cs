    char WheelID = 'A';
    int FilterPos = 4;
    NewName = "FriendlyName";
    
    string SettingIWant = WheelID.ToString() + FilterPos.ToString();
    Dictionary<string, string> properties = new Dictionary<string, string>()
    properties.Add(SettingIWant, NewName);
