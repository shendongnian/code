    private int hWorked; // the name field. It will be used internally to hold to value.
    public int HoursWorked // the Name property. User will use with object of class.
    {
        get
        {
            return hWorked;
        }
        set
        {
            hWorked = value; //  "value" is the actual value (here int) which is assigned by user while accessing this property from somewhere in other class or same class.
        }
    }
