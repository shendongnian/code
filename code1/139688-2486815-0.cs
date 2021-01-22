    void FiddleWithObject(object obj)
    {
        if (obj is IFiddly)
        {
            // Cool
            obj.Fiddle();
        }
        else
            throw new Exception("Wrong type of object");
    }
