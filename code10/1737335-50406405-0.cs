    [FieldOffset(0x14)]
    public fixed char Name[25];
    public string getName
    {
        get
        {
            fixed (char* namePtr = Name)
            {
                return new string(namePtr);
            }
        }
    }
