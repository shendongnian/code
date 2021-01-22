    abstract class Case
    {
        abstract char GetItem(int index);
    }
    class LowerCase : Case
    {
        override char GetItem(int index)
        {
            // Not sure for the following
            Encoding ascii = Encoding.ASCII;
            return ascii.GetString(ascii.GetBytes("a")[0] + index)[0];
        }
    }
    class UpperCase : Case
    {
        // The same for the upper case
    }
    public Case ChooseCase
    {
        get
        {
            if (condition)
            {
                return new LowerCase();
            }
            else
            {
                return new UpperCase();
            }
        }
    }
