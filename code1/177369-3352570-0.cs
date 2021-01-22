    public Color CustomColor
    {
       get { return GetValue(CustomColorProperty) as Color;}
    
       set 
       { 
          //check value before setting
          SetValue(CustomColorProperty, value);
       }
    }
