    for (int i = 1; i <= 5; i++){
        var numberofDomainsXAttributeValueId = setting.GetType().GetProperty($"NumberofDomains{i}AttributeValueId")
                                                                                             ?.GetValue(setting);
        if (numberofDomainsXAttributeValueId != null 
            && idOfNumberOfDomoinOrMulti == (int) numberofDomainsXAttributeValueId)
        {
            numberOfDomain = i;
            break;
        }
    }
