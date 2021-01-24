    public string this[int i]
    {
       get => types[i];
       set => types[i] = value;
    }
    // equivalent 
    public string this[int i]
    {
       get
       {
           return types[i];
       }
       set
       {
           types[i] = value;
       }
    }
