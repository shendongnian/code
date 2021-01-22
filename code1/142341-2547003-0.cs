    switch (kvp.Key) 
                { 
                    case MyEnum.Enum1: 
                        UpdateUI( Label1, someDictionary[kvp.Key] );
                        break; 
                    case MyEnum.Enum2: 
                        UpdateUI( Label2, someDictionary[kvp.Key] );
                        break; 
                    case MyEnum.Enum3: 
                        UpdateUI( Label3, someDictionary[kvp.Key] );
                        break; 
                }
    public void UpdateUI( Label theLabel, bool whichOne )
    {
         theLabel.ForeColor = whichOne ? Color.LimeGreen : Color.Red;
    }
