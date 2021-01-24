    public List<string> InfoMessages
    {
        get 
        { 
             // Some view has accessed the data, clear the list before returning
             var tempInfoMessages = new List<string>(_infoMessages);
             _infoMessages.Clear();
             return tempInfoMessages; 
        }
    }
