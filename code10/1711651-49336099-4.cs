    int proprtyCount = dictionary.Keys.Count;
    var conditions = new PropertyCondition[propertyCount];
    int index = 0;
    foreach (KeyValuePair<object, object> pair in dictionary)
        {
        conditions[i] = new PropertyCondition(pair.Key, pair.Value));
        index++;
        }
        
    var conditionEnabledButtons = new AndCondition(conditions);
        
