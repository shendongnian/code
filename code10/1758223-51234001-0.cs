    public class numerictext : EditText
    {
        public numerictext(Context context) : base(context)
                                          //^^^^^^^^^^^^^^^ 
                                          //Note how we are now calling the base constructure
        {
            //empty or you can add your own code
        }
        public numerictext(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }
        //etc
    } 
