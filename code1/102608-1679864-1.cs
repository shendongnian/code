    bool bItemExists = false;
    foreach(KeyValuePair<string, float> pItem in rollingPriceSupp)
    {
       if(pItem.Key == "Personal Insurance")
       {
          bItemExists = true;
          break;
       }
    }
    if(!bItemExists)
    {
        rollingPriceSupp.Add(new KeyValuePair<string, float>("Personal Insurance",
                                                           (float)insuranceCost));
    }
