    public static Points _points { get; set; }
    
    class Points
    {
        private int? i; 
        public static implicit operator Points(int value)
        {
            return new Points { i.Value = value };
        }
        public static implicit operator string(Points value)
        {
             if(Value.i.HasValue)
                 return value.i.Value.ToString();
              return "";
        }
         public static implicit operator int(Points value)
        {   
            return value.I.HasValue ?value.i.value : 0;
        }
    }
