    public abstract class BaseStyleType {}
    public class ImageStyle  : BaseStyleType {}
    public class TextStyle   : BaseStyleType {}
    public class ButtonStyle : BaseStyleType {}
    //...etc
    
    public class GlobalStyle <List1Type, List2Type, List3Type, ... > : ASerializedObject
    {
        public List<List1Type>  ImageStyles     = new List<List1Type>();
        public List<List2Type>   TextStyles      = new List<List2Type>();
        public List<List3Type> ButtonStyles    = new List<List3Type>();
        //... etc
    
        // Setter
        public void SetStyle(BaseStyleType inStyle)
        { 
            if (inStyle as ImageStyle != null)
                ImageStyles.Add((ImageStyle)inStyle);
            else if (inStyle as TextStyle != null)
                TextStyles.Add((TextStyle)inStyle);
            else if (inStyle as ButtonStyle != null)
                ButtonStyles.Add((ButtonStyle)inStyle);
            //... etc
        }
    
        // Getter
        public T GetStyle<T>(int index)
        {
            //...?
        }
    }
