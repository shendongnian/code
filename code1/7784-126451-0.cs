    public IList ListOfB
    {
        get 
        {
            if (_readOnlyMode) 
                return listOfB.AsReadOnly(); // also use ArrayList.ReadOnly(listOfB);
            else
                return listOfB;
        }
    }
