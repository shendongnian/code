    public OurNumericEditor<T> : Infragistics.Win.UltraWinEditors.UltraNumericEditor  
    
     public T Value  
        {
            get
            {
                return (T) base.Value;
            }
            set
            {
                // make sure what we're setting isn't outside the min or max
                // if it is, set value to the min or max instead
    
                double min = (double)MinValue;
                double max = (double)MaxValue;
                double attempted = // explicit conversion code goes here
    
                if (attempted > max)
                    base.Value = max;
                else if (attempted < min)
                    base.Value = min;
                else
                    base.Value = value;
            }
        }
    }
