    public class ExtendedPIO_CARD : PIO_CARD
    {
        public string FirstColumn
        {
            get
            {
                if (cflag == 8)
                {
                    return "R";
                }
                if(cflag == 0)
                {
                    return  string.Empty;
                }
                return "default";
            }
        } 
    }
