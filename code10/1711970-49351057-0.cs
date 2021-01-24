     public NormalColor CLR 
     { 
        get; 
        private set; 
     }
     public enum NormalColor
     {
        Red,
        Blue,
        Yellow
     }
    #region Constructor
    public CustomButton(NormalColor backgroundColor)
    {
        CLR = backgroundColor;
        if (CLR == NormalColor.Blue)
        {
            BackColor = Color.Blue;
        }
       /*Your other code*/
     }
    }
