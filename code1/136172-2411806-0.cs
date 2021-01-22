    public Machine SomeFunction(string name) 
    { 
        lock (_dictionary)
        {
            Machine result;
            if (!_dictionary.TryGetValue(name, out result))
            {
                result = CreateMachine(name);
                _dictionary[name] = result;
            }
            return result;
        } 
    }
    // This is now *just* responsible for creating the machine,
    // not for maintaining the dictionary. The dictionary manipulation
    // is confined to the above method.
    private Machine CreateMachine(string name)
    {
        return new Machine(name);
    }
