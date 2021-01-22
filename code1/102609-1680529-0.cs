    // this function will give you a Predicate to check for any key
    public Predicate<KeyValuePair<string, float>> GetMatcher(string key) {
        return (KeyValuePair<string, float> item) => { item.Key == key; }
    }
    int index = rollingPriceSupp.FindIndex(GetMatcher("Personal Insurance"));
    bool keyExists = (index == -1);
    
    if (!keyExists && !isDirectUK) {
        rollingPriceSupp.Add(new KeyValuePair<string, float>("Personal Insurance",
                                                             (float)insuranceCost));
    }
