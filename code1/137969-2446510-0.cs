    public class PicturedLabel : Label
    {
        protected Image
        {
            get {...}
            set {...}
        }
        ............
    }
    
    public class TypedLabel : PicturedLabel
    {
        public TypedLabel(LabelType type)
           :base(...)
        {
           Type = type;
        }
        private LabelType Type
        {
          set 
          {
             Image = GetImageFromType(value, LabelColor);
          }
        }
    }
