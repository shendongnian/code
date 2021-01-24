    public void AssignName(string name)
    {
        if (name == null)
        {
            //WRONG!!!
            // Exception is the base class, this doesn't provide you anything meaningful 
            throw new Exception("name is null!!!);
            //Correct:
            // ArgumentNullException tells you that a null value was passed when this isn't valid
            throw new ArgumentNullException("name");
        }
    }
